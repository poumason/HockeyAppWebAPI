<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="HockeyAppAPIWeb.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <%--<div>
        <asp:Button runat="server" ID="GetApp" Text="Get Apps" OnClick="GetApp_Click" />
        <br />
        <table>
            <tr>
                <td><span>App Id:</span></td>
                <td><asp:TextBox runat="server" ID="txtAppId" /></td>
                <td>
        <asp:Button runat="server" ID="GetVersion" Text="Get Versions" OnClick="GetVersion_Click" /></td>
            </tr>
        </table>
        <br />
        <table>
            <tr>
                <td>Version:</td>
                <td><asp:TextBox runat="server" ID="txtVersion" /></td>
                <td></td>
            </tr>
            <tr>
                <td>Reason Id:</td>
                <td><asp:TextBox runat="server" ID="txtResonId" /></td>
                <td><asp:Button runat="server" ID="WriteCrash" Text="WriteCrash" OnClick="WriteCrash_Click" /></td>
            </tr>
        </table>        
        <br />
        <asp:Label runat="server" ID="lablLog" />
    </div>--%>
        <div>
            <table border="1">
                <tr>
                    <td>App Id:</td>
                    <td><asp:TextBox runat="server" ID="txtAppId" /></td>
                </tr>
                <tr>
                    <td>Version Id:</td>
                    <td><asp:TextBox runat="server" ID="txtVersion" /></td>
                </tr>
                <tr>
                    <td>Reason Id:</td>
                    <td><asp:TextBox runat="server" ID="txtReasonId" /></td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button runat="server" Text="Download db File" OnClick="OnDownloadDbFile_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
