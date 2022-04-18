<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PrimaxBPM2ToolWeb._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>

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

    <table width="300" border="1" >
        <tr>
            <td>
                小白測試目前流程
            </td>
            <td>
                <asp:DropDownList ID="ddlFlowList2" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btnFlow2" Text="小白建立流程" runat="server" 
                    onclick="btnFlow2_Click" />
                <asp:Label ID="lbMsg2" runat="server"></asp:Label>
            </td>
        </tr>
       
    </table>
    <br />
    <asp:HyperLink ID="hy1" runat="server" Text="產生核決權限資料" NavigateUrl="~/GenerateFlowPolicy.aspx"></asp:HyperLink>
    
   <%-- <asp:Button ID="Button1" runat="server" Text="延休申請流程建立" onclick="Button1_Click" />
    <br />
    
    <asp:Button ID="btnFlexTime" runat="server" Text="彈性工時申請流程建立" 
            onclick="btnFlexTime_Click"  />
    <br />
    
    <asp:Button ID="Button3" runat="server" Text="台灣請假申請流程建立" onclick="Button3_Click" 
             />
    <br />
    
    <asp:Button ID="Button4" runat="server" Text="台灣請假取消申請流程建立" 
            onclick="Button4_Click"    />
        <br />
        <br />
    
    <asp:Button ID="Button5" runat="server" Text=" 加班申請流程建立" 
            onclick="Button5_Click"    />
        <br />
        <br />
    
    <asp:Button ID="Button6" runat="server" Text="  年度計畫流程建立" 
            onclick="Button6_Click"    />
    <br />
    <asp:Label ID="lbMsg1" runat="server"></asp:Label>
        <%--<asp:Button ID="btnInsertProcess" runat="server" Text="建立流程" 
            onclick="btnInsertProcess_Click" />--%>
    <br />
    
   <%-- <asp:Button ID="Button2" runat="server" Text="測試流程數" onclick="Button2_Click"  />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="true"></asp:GridView>
    </div>--%>
    </form>
</body>
</html>
