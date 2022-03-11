<%@ Page Title="Users" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="WebMaintenance.Users" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>

    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="View1" runat="server">
            <table>
                <tr>
                    <td colspan="3">
                        <h4>Add/Edit User</h4>
                        <p><asp:LinkButton ID="LinkButton4" runat="server" OnClick="LinkButton4_Click" >List of Users</asp:LinkButton></p>
                    </td>
                </tr>
                <tr>
                    <td>Select Company</td>
                    <td rowspan="4" style="width: 1%;" />
                    <td>
                        <asp:DropDownList ID="ddlCompany" runat="server">
                            <asp:ListItem Value="select">Select Company</asp:ListItem>
                            <asp:ListItem>Prince</asp:ListItem>
                            <asp:ListItem>DiNovo</asp:ListItem>
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td>Select User</td>
                    <td>
                        <asp:DropDownList ID="ddlUser" runat="server">
                            <asp:ListItem Value="select">Select Select</asp:ListItem>
                            <asp:ListItem>Prince User</asp:ListItem>
                            <asp:ListItem>DiNovo User</asp:ListItem>
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td>Select User Type</td>
                    <td>
                        <asp:RadioButtonList ID="optUserType" runat="server">
                            <asp:ListItem Value="0">User</asp:ListItem>
                            <asp:ListItem Value="1">Administrator</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td>Select Status</td>
                    <td>
                        <asp:RadioButtonList ID="optUserStatus" runat="server">
                            <asp:ListItem Value="0">Inactive</asp:ListItem>
                            <asp:ListItem Value="1">Active</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="btnSendRequest" runat="server" Text="Send Reuest" OnClick="btnSendRequest_Click" /><asp:Button ID="btnCancelRequest" runat="server" Text="Cancel" /></td>
                </tr>
            </table>
        </asp:View>
        <asp:View ID="View2" runat="server">
            <table>
                <tr>
                    <td colspan="3">
                        <h4>Change Password</h4>
                    </td>
                </tr>
                <tr>
                    <td>Change Password</td>
                    <td style="width: 1%;" />
                    <td>
                        <asp:TextBox ID="txtChangePsw" runat="server"></asp:TextBox>
                    </td>
                </tr>
                 </table>
             <table>
                <tr>
                    <td colspan="7">
                        <h4>Select Q&A</h4>
                    </td>
                </tr>
                <tr>
                    <td>Q1</td>
                    <td rowspan="3" style="width: 1%;" />
                    <td>
                        <asp:DropDownList ID="ddlQ1" runat="server">
                            <asp:ListItem Value="select">Select Q1</asp:ListItem>
                            <asp:ListItem>Question A</asp:ListItem>
                            <asp:ListItem>Question B</asp:ListItem>
                            <asp:ListItem>Question C</asp:ListItem>
                        </asp:DropDownList></td>
                    <td rowspan="3" style="width: 1%;" />
                     <td>A1</td>
                    <td rowspan="3" style="width: 1%;" />
                    <td>
                        <asp:TextBox ID="txtA1" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Q2</td>
                    
                    <td>
                        <asp:DropDownList ID="ddlQ2" runat="server">
                            <asp:ListItem Value="select">Select Q2</asp:ListItem>
                            <asp:ListItem>Question D</asp:ListItem>
                            <asp:ListItem>Question E</asp:ListItem>
                            <asp:ListItem>Question F</asp:ListItem>
                        </asp:DropDownList></td>
                    
                     <td>A2</td>
                    
                    <td>
                        <asp:TextBox ID="txtA2" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Q3</td>
                    
                    <td>
                        <asp:DropDownList ID="ddlQ3" runat="server">
                            <asp:ListItem Value="select">Select Q3</asp:ListItem>
                            <asp:ListItem>Question G</asp:ListItem>
                            <asp:ListItem>Question H</asp:ListItem>
                            <asp:ListItem>Question I</asp:ListItem>
                        </asp:DropDownList></td>
                    
                     <td>A3</td>
                    
                    <td>
                        <asp:TextBox ID="txtA3" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="7">
                        <asp:Button ID="btnUpdatePsw" runat="server" Text="Update Password" OnClick="btnUpdatePsw_Click" /><asp:Button ID="btnCancelUpdate" runat="server" Text="Cancel" OnClick="btnCancelUpdate_Click" /></td>
                </tr>
            </table>
        </asp:View>
        <asp:View ID="View3" runat="server">
            <p><asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">Add User</asp:LinkButton></p>
            <asp:Table ID="Table1" runat="server">
                <asp:TableHeaderRow>
                    <asp:TableHeaderCell></asp:TableHeaderCell>
                    <asp:TableHeaderCell>User</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Email</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Company</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Status</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Access</asp:TableHeaderCell>
                </asp:TableHeaderRow>
                <asp:TableHeaderRow>
                    <asp:TableCell>
                        <asp:LinkButton ID="LinkButton1" runat="server">Select</asp:LinkButton></asp:TableCell>
                </asp:TableHeaderRow>
                 <asp:TableHeaderRow>
                    <asp:TableCell>German Yemets</asp:TableCell>
                     <asp:TableCell>gyemets@princesterilization.com</asp:TableCell>
                     <asp:TableCell>Prince Sterilization Services</asp:TableCell>
                     <asp:TableCell>Active</asp:TableCell>
                     <asp:TableCell>Administrator</asp:TableCell>
                </asp:TableHeaderRow>
            </asp:Table>
            <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click"  />
        </asp:View>
        <asp:View ID="View4" runat="server">
            <table>
                <tr>
                    <td>
                        <h4>Confirmation</h4>
                    </td>
                </tr>
                <tr>
                    <td>Password Updated</td>
                     </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnOk" runat="server" Text="Ok" OnClick="btnOk_Click" />
                    </td>
                </tr>
                 </table>
        </asp:View>
        <asp:View ID="View5" runat="server">
             <asp:Table ID="Table2" runat="server">
                <asp:TableHeaderRow>
                    <asp:TableHeaderCell></asp:TableHeaderCell>
                    <asp:TableHeaderCell>User</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Email</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Company</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Status</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Access</asp:TableHeaderCell>
                </asp:TableHeaderRow>
                <asp:TableHeaderRow>
                    <asp:TableCell>
                        <asp:LinkButton ID="LinkButton3" runat="server">Select</asp:LinkButton></asp:TableCell>
                </asp:TableHeaderRow>
                 <asp:TableHeaderRow>
                    <asp:TableCell>German Yemets</asp:TableCell>
                     <asp:TableCell>gyemets@princesterilization.com</asp:TableCell>
                     <asp:TableCell>Prince Sterilization Services</asp:TableCell>
                     <asp:TableCell>Active</asp:TableCell>
                     <asp:TableCell>Administrator</asp:TableCell>
                </asp:TableHeaderRow>
            </asp:Table>
            <table>
                <tr>
                    <th colspan="3">User Data</th>
                </tr>                
                <tr>
                    <td>User</td>
                     <td rowspan="5" style="width: 1%;" />
                    <td>
                        <asp:DropDownList ID="DropDownList1" runat="server">
                            <asp:ListItem>German Yemets</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>Email</td>
                    <td>
                        <asp:TextBox ID="TextBox1" runat="server">gyemets@princesterilization.com</asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Company</td>
                    <td>
                        <asp:DropDownList ID="DropDownList2" runat="server">
                            <asp:ListItem>Prince Sterilization Services</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>Status</td>
                    <td>
                        <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="0">Inactive</asp:ListItem>
                            <asp:ListItem Value="1" Selected="True">Active</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                 <tr>
                    <td>User Type</td>
                    <td>
                        <asp:RadioButtonList ID="RadioButtonList2" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="0">User</asp:ListItem>
                            <asp:ListItem Value="1" Selected="True">Administrator</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:Button ID="btnSaveUser" runat="server" Text="Save User" OnClick="btnSaveUser_Click" /><asp:Button ID="btnCancelUser" runat="server" Text="Cancel" OnClick="btnCancelUser_Click" /></td>
                </tr>
            </table>
        </asp:View>
    </asp:MultiView>
</asp:Content>
