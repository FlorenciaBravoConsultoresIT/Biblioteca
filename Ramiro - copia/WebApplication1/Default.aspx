<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    

    <asp:Label Id="lblHola" runat="server"></asp:Label>

    <asp:TextBox ID="txtPrueba" runat="server"></asp:TextBox>

    <asp:DropDownList ID="ddlPaises" runat="server">
    </asp:DropDownList>

    <asp:Button Id="btnPrueba" Text="CLICK" OnClick="btnPrueba_Click" runat="server" />

    <asp:Label Id="lblBoton" runat="server"></asp:Label>

    <div class="row">
        <div class="col-md-12">
            
            <asp:GridView ID="grdPrueba" AutoGenerateColumns="false" runat="server">
                <Columns>
                    <%--<asp:BoundField DataField="Id" HeaderText="ID" />--%>
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre Pais" />
                    <%--<asp:BoundField DataField="Continente" HeaderText="Nombre Continente" />--%>
                </Columns>
            </asp:GridView>

        </div>
    </div>


</asp:Content>
