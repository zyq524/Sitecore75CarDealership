<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="CarDealership.Web.layouts.CarDealership.Search" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title></title>
  <link rel="stylesheet" href="../../Content/bootstrap.min.css">
  <link rel="stylesheet" href="../../Content/Site.css" />
</head>
<body>
  <div class="container">
    <h2>Search for customers</h2>
    <div class="row">
      <div class="col-lg-2">
        <div class="btn-group">
          <a class="btn btn-primary dropdown-toggle" data-toggle="dropdown" href="#">Search by <span class="caret"></span></a>
          <ul class="dropdown-menu">
          </ul>
        </div>
      </div>
    </div>

    <div class="row">
      <div class="col-lg-6">
        <form class="navbar-form">
          <input id="searchCutomer" type="text" class="form-control" placeholder="Search..." disabled="disabled">
        </form>
      </div>
   </div>

    <div class="row">
      <div class="col-lg-3">
        <div id="list-customer" class="list-group">
        </div>
      </div>
      <div class="col-lg-6">
        <ul class="list-group" id="list-carpurchase"></ul>
      </div>
    </div>
  </div>
  <script src="../../Scripts/jquery.min.js"></script>
  <script src="../../Scripts/bootstrap.min.js"></script>
  <script>
    $(document).ready(function () {
      getCustomers('/sitecore/api/ssc/cardealership-services-controller/customer');

      $(document).on("click", "#list-customer a", function (e) {
        e.preventDefault();
        $("#list-carpurchase").empty();
        $.ajax({
          url: '/sitecore/api/ssc/cardealership-services-controller/carpurchase/na/getbycustomerid?customerid=' + $(this).data("id"),
        }).done(function (carpurchases) {
          $("#list-carpurchase").empty();
          for (var i = 0; i < carpurchases.length; i++) {
            var carpurchase = carpurchases[i];
            $.ajax({
              url: '/sitecore/api/ssc/cardealership-services-controller/car/' + carpurchase.Car,
            }).done(function (car) {
              $.ajax({
                url: '/sitecore/api/ssc/cardealership-services-controller/salesperson/' + carpurchase.SalesPerson,
              }).done(function (salesperson) {
                var listText = '';
                listText += '<li class="list-group-item">' + car.Extras + ', ' + carpurchase.PricePaid + ', ' +
                  salesperson.SalesPersonName + ', ' + new Date(carpurchase.OrderDate).toLocaleDateString() + '</li>';
                $("#list-carpurchase").append(listText);
              });

            });
          }
        });
      });

      var restUrl = "";

      $.ajax({
        url: '/sitecore/api/ssc/cardealership-services-controller/searchconstraint',
      }).done(function (data) {
        var listText = '';
        for (var i = 0; i < data.length; i++) {
          listText += '<li><a href="#" data-uri="' + data[i].RestUri + '">' + data[i].SearchConstraintName + '</a></li>';
        }
        $(".dropdown-menu").append(listText);

        $(".dropdown-menu li a").click(function () {
          $("input.form-control").attr("disabled", false);
          restUrl = $(this).data("uri");

          var selText = $(this).text();
          var toggleBtn = $(this).parents('.btn-group').find('.dropdown-toggle');
          toggleBtn.html(selText + ' <span class="caret"></span>');
        });
      });

      $("#searchCutomer").keyup(function () {
        if (!$(this).val()) {
          getCustomers('/sitecore/api/ssc/cardealership-services-controller/customer');
        }
      });

      $('#searchCutomer').keypress(function (e) {
        if (e.which == '13') {
          var searchText = $(this).val();

          if (!searchText) {
            return;
          }
          getCustomers(restUrl, searchText);
        }
      });

      function getCustomers(baseUrl, searchText) {
        if (!baseUrl) {
          return;
        }

        var url = baseUrl;
        if (searchText) {
          url = url + searchText;
        }
        $.ajax({
          url: url,
        }).done(function (data) {
          $("#list-customer").empty();
          $("#list-carpurchase").empty();

          var listText = '';
          for (var i = 0; i < data.length; i++) {
            listText += '<a href="#" class="list-group-item" data-id="' + data[i].Id + '">' + data[i].CustomerName + ' ' +
              data[i].Surname + ', ' + data[i].Age + ' år, ' + data[i].Street + ' ' + data[i].HouseNumber + ', ' +
              data[i].ZipCode + ', ' + data[i].Town + ', ' + data[i].Country + '</a>';
          }
          $("#list-customer").append(listText);
        });
      }
    });
  </script>
</body>
</html>
