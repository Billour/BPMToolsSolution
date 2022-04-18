<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="RuleEngineWebApp._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <div>
        <table>
            <tr>
                <td colspan="2">L9/L10 L12/L13</td>
            </tr>
            <tr>
                <td>天數:</td>
                <td><asp:TextBox ID="tbDays" runat="server" Text="3"></asp:TextBox></td>
            </tr>
            <tr>
                <td>申請人職級:</td>
                <td><asp:TextBox ID="tbApplicantRank" runat="server" Text="P2"></asp:TextBox></td>
            </tr>
            <tr>
                <td>審核人職級:</td>
                <td><asp:TextBox ID="tbRank" runat="server" Text="L9"></asp:TextBox></td>
            </tr>
            <tr>
                
                <td><asp:Button ID="btnClick" runat="server" Text="按一下" onclick="btnClick_Click" /></td>
                <td><asp:Label ID="lbResultMsg" runat="server"></asp:Label></td>
            </tr>
        </table>
        <br />
        
        <table>
            <tr><td>加班核決權限表</td></tr>
            <tr><td>
                地區
                <asp:RadioButtonList ID="rdlZone" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Text="北京" Value="1"></asp:ListItem>
                    <asp:ListItem Text="廣州" Value="2"></asp:ListItem>
                    <asp:ListItem Text="東聚" Value="3"></asp:ListItem>
                    <asp:ListItem Text="昆山" Value="4"></asp:ListItem>
                </asp:RadioButtonList>
             </td></tr>
            <tr><td>
                加班類型
                <asp:RadioButtonList ID="rdlOverTimeType" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Text="平日加班" Value="WEEKDAY"></asp:ListItem>
                    <asp:ListItem Text="週末加班" Value="HOLIDAY"></asp:ListItem>
                    <asp:ListItem Text="國定假日加班" Value="NATIONAL"></asp:ListItem>
                </asp:RadioButtonList>
                
                
            </td></tr>
            <tr><td>審核人職級<asp:TextBox ID="tbRankText" runat="server" Text="L6"></asp:TextBox></td></tr>
            <tr><td>開始測試：<asp:Button ID="btnChcek" runat="server" Text="開始測試" 
                    onclick="btnChcek_Click" /><asp:Label ID="lbCNMsg" runat="server"></asp:Label></td></tr>
        </table>
        
        <br />
        <table>
            <tr><td>
                    台灣請假資料超過十天設定<br />
                    (01002089,01002308,01001912)<br />
                    (01002917,01001135,01000405,01000522)
            </td></tr>
            <tr><td>SEQUENTIAL_CURRENT_INDEX:<asp:TextBox ID="SeqIndex" runat="server" Text="-1"/></td></tr>
            <tr><td>LEAVE_DAYS:<asp:TextBox ID="LeaveDays" runat="server" Text="1"/></td></tr>
            <tr><td>APPLICANT:<asp:TextBox ID="Applicant" runat="server" Text="01002089"/></td></tr>
            <tr><td>BU_HEAD:<asp:TextBox ID="BUHead" runat="server" Text="01001912" /></td></tr>
            <tr><td>CEO:<asp:TextBox ID="CEO" runat="server" Text="01000001"/></td></tr>
            <tr><td>PERSON_ID:<asp:TextBox ID="PersonID" runat="server" Text="01002308" /></td></tr>
            <tr><td>
                <asp:Button ID="btnLeaveDays" runat="server" Text="超過十天" onclick="btnLeaveDays_Click" />
                <br />
                <asp:Label ID="txtTWMsg" runat="server"></asp:Label>
            </td></tr>
        </table>
        
    </div>
    </div>
    </form>
</body>
</html>
