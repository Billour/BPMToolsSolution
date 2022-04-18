<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestSeqFlow.aspx.cs" Inherits="BPM2ToolWeb.TestSeqFlow" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table>
            <tr>
                <td>
                    個人資料
                </td>
                <td>
                    <asp:TextBox ID="tbPersonId" runat="server" Text="DTCB\DTCB0059"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    核決權限表
                </td>
                <td>
                    <asp:TextBox ID="tbPolicy" runat="server" Text="職級休假天數權限檢核"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="btnClick" runat="server" Text="產生核決權限表" onclick="btnClick_Click" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="true"></asp:GridView>
                </td>
            </tr>
        </table>
        
    </div>
    </form>
</body>
</html>
