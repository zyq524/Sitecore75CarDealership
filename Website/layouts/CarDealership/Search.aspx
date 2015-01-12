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
      <div class="col-lg-1">
        <div class="btn-group">
          <a class="btn btn-primary dropdown-toggle" data-toggle="dropdown" href="#">Seach by <span class="caret"></span></a>
          <ul class="dropdown-menu">
            <li><a href="#">Item I</a></li>
            <li><a href="#">Item II</a></li>
            <li><a href="#">Item III</a></li>
            <li><a href="#">Item IV</a></li>
            <li><a href="#">Item V</a></li>
          </ul>
        </div>
      </div>
      <div class="col-lg-6">
        <form class="navbar-form">
          <input type="text" class="form-control" placeholder="Search...">
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
    $(".dropdown-menu li a").click(function () {
      var selText = $(this).text();
      $(this).parents('.btn-group').find('.dropdown-toggle').html(selText + ' <span class="caret"></span>');
    });
  </script>
</body>
</html>
