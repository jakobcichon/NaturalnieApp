<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ASP.NET_Sample._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <style type="text/css">
        #form1
        {
            height: 629px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    <asp:Label ID="Label1" runat="server" Text="Label File Name: "></asp:Label>
    <asp:Label ID="labelFileNamelbl" runat="server" Text="Label"></asp:Label>
    <p>
        <asp:Label ID="Label6" runat="server" Text="Recently Used Labels"></asp:Label>
    </p>
    <p>
        <asp:DropDownList ID="mruCmb" runat="server" AutoPostBack="True" Height="16px" 
            onselectedindexchanged="mruCmb_SelectedIndexChanged" Width="424px">
        </asp:DropDownList>
    </p>
    <p>
        <asp:Label ID="Label2" runat="server" Text="LabelWriter Printer"></asp:Label>
    </p>
    <asp:DropDownList ID="printersCmb" runat="server" Height="16px" Width="428px">
    </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="printBtn" runat="server" Text="Print Label" Width="124px" 
        onclick="printBtn_Click" />
    <p>
        <asp:Label ID="Label3" runat="server" Text="TwinTurbo Tray"></asp:Label>
    </p>
    <asp:DropDownList ID="trayCmb" runat="server" Height="16px" Width="172px">
        <asp:ListItem>Left</asp:ListItem>
        <asp:ListItem>Right</asp:ListItem>
        <asp:ListItem>Auto</asp:ListItem>
    </asp:DropDownList>
    <p>
        <asp:Label ID="Label4" runat="server" Text="Label Object Name"></asp:Label>
    </p>
    <asp:DropDownList ID="objNamesCmb" runat="server" Height="17px" Width="281px" 
        onselectedindexchanged="objNamesCmb_SelectedIndexChanged" 
        AutoPostBack="True">
    </asp:DropDownList>
    <p>
        <asp:Label ID="Label5" runat="server" Text="Label Object Data"></asp:Label>
    </p>
    <asp:TextBox ID="objDataEdit" runat="server" Height="218px" 
        TextMode="MultiLine" Width="359px"></asp:TextBox>
    <br />
    <br />
    <asp:Button ID="setObjDataBtn" runat="server" Text="Set Data" Width="106px" 
        onclick="setObjDataBtn_Click" />
    </form>
</body>
</html>
