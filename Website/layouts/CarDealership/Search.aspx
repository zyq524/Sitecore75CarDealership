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
          <input type="text" class="form-control" placeholder="Search..." disabled="disabled">
        </form>
      </div>
    </div>

    <div class="row">
      <div class="col-lg-3">
        <div class="list-group">
          <a href="#" class="list-group-item active">Cras justo odio
          </a>
          <a href="#" class="list-group-item">Dapibus ac facilisis in</a>
          <a href="#" class="list-group-item">Morbi leo risus</a>
          <a href="#" class="list-group-item">Porta ac consectetur ac</a>
          <a href="#" class="list-group-item">Vestibulum at eros</a>
        </div>
      </div>
    </div>

  </div>

  <script src="../../Scripts/jquery.min.js"></script>
  <script src="../../Scripts/bootstrap.min.js"></script>
  <script>
    $(document).ready(function () {
      $.ajax({
        url: '/sitecore/api/ssc/cardealership-services-controller/searchconstraint',
      }).done(function (data) {
        var listText = '';
        for (var i = 0; i < data.length; i++) {
          listText += '<li><a href="#" data-uri="' + data[i].RestUri + '">' + data[i].Name + '</a></li>';
        }
        $(".dropdown-menu").append(listText);

        $(".dropdown-menu li a").click(function () {
          $("input.form-control").attr("disabled", false);

          var selText = $(this).text();
          var toggleBtn = $(this).parents('.btn-group').find('.dropdown-toggle');
          toggleBtn.attr("data-uri", $(this).data("uri"));
          toggleBtn.html(selText + ' <span class="caret"></span>');
        });
      });
    });

  </script>
</body>
</html>
