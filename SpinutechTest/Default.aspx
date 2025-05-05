<%@ Page Title="Home Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <form method="post" action="/">

    <div class="row">
    <div class="col-lg-3">
        <div class="input-group">
          <asp:TextBox ID="txtValue" runat="server" CssClass="form-control" placeholder="Type a number"></asp:TextBox>
          <span class="input-group-btn">
            <button class="btn btn-default" type="submit">Submit</button>
          </span>
        </div>
      </div>
    </div>
   </form>
    <asp:Label ID="lblMsg" runat="server"></asp:Label>
<asp:Table ID="Table1" runat="server" CssClass="table table-bordered " Height="123px" Width="567px"></asp:Table>



</asp:Content>
