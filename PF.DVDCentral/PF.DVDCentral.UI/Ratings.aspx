﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Ratings.aspx.cs" Inherits="PF.DVDCentral.UI.Ratings" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div class="header rounded-top">
        <h3>Manage Ratings</h3>
    </div>
    <p></p>

    <div class="form-row ml-2 mt-2">
        <div class="control-label col-md-2">
            <asp:Label ID="Label2" runat="server" Text="Ratings:"></asp:Label>
        </div>
        <div class="control-label col-md-3">
            <asp:DropDownList ID="ddlRatings"
                runat="server"
                CssClass="form-control"
                AutoPostBack="true"
                OnSelectedIndexChanged="ddlRatings_SelectedIndexChanged">
            </asp:DropDownList>
        </div>
    </div>

    <div class="form-row ml-2 mt-2">
        <div class="control-label col-md-2">
            <asp:Label ID="Label3"
                runat="server"
                Text="Description:"></asp:Label>
        </div>
        <div class="control-label col-md-3">
            <asp:TextBox ID="txtDescription"
                runat="server"
                CssClass="form-control"></asp:TextBox>
        </div>
    </div>

    

    <div class="form-group ml-5 mt-2">
        <asp:Button ID="btnInsert" runat="server" CssClass="btn btn-primary btn-md ml-3" Text="Insert" OnClick="btnInsert_Click" />
        <asp:Button ID="btnUpdate" runat="server" CssClass="btn btn-primary btn-md ml-3" Text="Update" OnClick="btnUpdate_Click" />
        <asp:Button ID="btnDelete" runat="server" CssClass="btn btn-primary btn-md ml-3" Text="Delete" OnClick="btnDelete_Click" />
    </div>
</asp:Content>
