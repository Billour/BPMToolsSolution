<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BPM2ToolWeb._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Panel ID="pnl1" runat="server" Visible="false">
        <table width="300" border="1" >
        <tr>
            <td>
                文斌測試目前流程
            </td>
            <td>
                <asp:DropDownList ID="ddlFlowList" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btnFlowClick" Text="建立流程" runat="server" onclick="btnFlowClick_Click" />
                <asp:Label ID="lbFlowMsg" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
    </asp:Panel>
    

    <table width="300" border="1" >
        <tr>
            <td>
                上流程
            </td>
            <td>
               平台:
               <asp:DropDownList ID="ddlPlatform" runat="server">
                    <asp:ListItem Text="Portal_86_Agile_VM" Value="QA" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="Portal_87_Agile_19" Value="Test" ></asp:ListItem>
                    <asp:ListItem Text="Portal_Nick_Agile_VM" Value="Bin"></asp:ListItem>
                    <asp:ListItem Text="Portal_87_Agile_正式機" Value="Production"></asp:ListItem>
               </asp:DropDownList>
                <br />
                流程：
                <asp:DropDownList ID="ddlFlowList2" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btnFlow2" Text="建新流程" runat="server" 
                    onclick="btnFlow2_Click" />
                <asp:Label ID="lbMsg2" runat="server"></asp:Label>
            </td>
        </tr>
       
    </table>
    <br />
    <asp:HyperLink ID="hy1" runat="server" Text="產生核決權限資料" NavigateUrl="~/GenerateFlowPolicy.aspx"></asp:HyperLink>
    
    <br />
    <asp:HyperLink ID="HyperLink1" runat="server" Text="產生Mail Template" NavigateUrl="~/MailTemplateRegister.aspx"></asp:HyperLink>
  
    </form>
</body>
</html>
