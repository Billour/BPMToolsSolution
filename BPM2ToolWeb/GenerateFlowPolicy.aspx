<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GenerateFlowPolicy.aspx.cs" Inherits="BPM2ToolWeb.GenerateFlowPolicy" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table>
            <tr>
                <td>平台:</td>
                <td>
                   <asp:DropDownList ID="ddlPlatform" runat="server">
                        <asp:ListItem Text="Portal_86_Agile_VM" Value="QA" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="Portal_87_Agile_19" Value="Test" ></asp:ListItem>
                        <asp:ListItem Text="Portal_Nick_Agile_VM" Value="Bin"></asp:ListItem>
                        <asp:ListItem Text="Portal_87_Agile_正式機" Value="Production"></asp:ListItem>
                   </asp:DropDownList>
                <br />
                流程：
                </td>
            </tr>
        </table>
    
       <asp:Button ID="btnUTD3Policy" runat="server" Text="產生台灣核決權限XML" 
            onclick="btnTWPolicy_Click" />
        <asp:Label ID="lbMsg1" runat="server"></asp:Label>
        
        <br />
        <asp:Button ID="btnInsertCNLeave" runat="server" Text="InsertTaiwanPolicyToDB" 
            onclick="btnInsertTWLeave_Click" />
        <br />
       
        <asp:Button ID="btnCNPolicyXML" runat="server" Text="產生大陸核決權限XML" 
            onclick="btnCNPolicyXML_Click" />
        <asp:Label ID="lbMsg2" runat="server"></asp:Label>
        
        <br />
        <asp:Button ID="btnCNToDB" runat="server" Text="更新大陸核決權限至資料庫" 
            onclick="btnCNToDB_Click" />
        <br />
        
    </div>
    </form>
</body>
</html>
