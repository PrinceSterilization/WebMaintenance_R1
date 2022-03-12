<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisteredUsers.aspx.cs" Inherits="WebMaintenance.RegisteredUsers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registered Users</title>
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="css/style.css" rel="stylesheet" />
    <link href="css/My_Style.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style32 {
            text-decoration: underline;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table class="borderless" style="width: 1200px;">
            <tr>
                <th><%--style="align-items: center; vertical-align: middle; width: 99%; border: none;"--%>
                    <div class="row" style="align-items: center;">
                        <div class="col-md-2">&nbsp;</div>
                        <div class="col-md-8" style="align-content: center; align-items: center; align-self: center;">
                            <h1>
                                <img src="<%=ResolveClientUrl("img/PSS_xSmall.jpg")%>" />
                                WEB MAINTENANCE</h1>
                            <hr style="border: thin solid #003366;" />
                            <h2><%: Title %></h2>
                        </div>
                        <div class="col-md-2">&nbsp;</div>
                    </div>
                </th>
            </tr>

            <tr>

                <td>
                    <div class="row">
                        <div class="col-md-2">&nbsp;</div>
                        <div class="col-md-8">
                            <h3>Instructions</h3>
                            <p>Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.</p>
                        </div>
                        <div class="col-md-2">
                            <asp:Button ID="Button1" runat="server" Text="Users View" OnClick="Button1_Click" /><asp:Button ID="Button2" runat="server" Text="Add New View" OnClick="Button2_Click" /><asp:Button ID="Button3" runat="server" Text="Messages View" OnClick="Button3_Click" />&nbsp;</div>
                    </div>
                </td>
            </tr>

            <tr>
                <td>
                    <div class="row">
                        <div class="col-md-2">&nbsp;</div>
                        <div class="col-md-8">
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" />
                            <asp:MultiView ID="MultiView1" runat="server">
                                <asp:View ID="View1" runat="server">
                                    <div class="container">
                                        <h4><u>Users</u></h4>
                                        <div class="row" style="margin-top: 20px;">
                                            <div class="col-md-10">
                                                &nbsp;
                                            </div>
                                            <div class="col-md-2">
                                                <asp:LinkButton ID="lbtnAddNew" runat="server">Add User</asp:LinkButton>
                                            </div>
                                        </div>
                                        <div class="row" style="margin-top: 20px;">
                                            <div class="col-md-12">
                                                <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                    <EditRowStyle BackColor="#999999" />
                                                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                                </asp:GridView>
                                            </div>
                                        </div>
                                    </div>
                                </asp:View>
                                <asp:View ID="View2" runat="server">
                                    <div class="container">
                                        <h4><u>Section Add User</u></h4>
                                        <div class="row" style="margin-top: 20px;">
                                            <div class="col-md-6">
                                                Company: <asp:DropDownList ID="ddlCompany" runat="server"></asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlCompany" ErrorMessage="A1">*</asp:RequiredFieldValidator>
                                            </div>
                                            <div class="col-md-6">
                                                Contact:
                                            <asp:DropDownList ID="ddlContact" runat="server"></asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlContact" ErrorMessage="A1">*</asp:RequiredFieldValidator>
                                            </div>
                                            
                                        </div>
                                        <div class="row" style="margin-top: 20px;">
                                            <div class="col-md-4">User Access:
                                                <asp:RadioButtonList ID="optUserAccess" runat="server" RepeatDirection="Horizontal" RepeatLayout="Table">
                                                    <asp:ListItem Selected="True" Value="0">User</asp:ListItem>
                                                    <asp:ListItem Value="1">Administrator</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </div>
                                            
                                            <div class="col-md-4">User Status:
                                                <asp:RadioButtonList ID="optUserStatus" runat="server" RepeatDirection="Horizontal" RepeatLayout="Table">
                                                    <asp:ListItem Value="0">Inactive</asp:ListItem>
                                                    <asp:ListItem Selected="True" Value="1">Active</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </div>
                                            <div class="col-md-4">&nbsp;</div>
                                        </div>                                       
                                        <hr />
                                       
                                        
                                        <div class="row" style="margin-top: 20px;">
                                            
                                            <div class="col-md-12">
                                                <asp:Button ID="btnSubmit" runat="server" Text="Submit" />
                                                <asp:Button ID="btnCancel" runat="server" CausesValidation="False" Text="Cancel" />
                                            </div>
                                            
                                        </div>
                                    </div>
                                </asp:View>
                                 <asp:View ID="View3" runat="server">
                                      <div class="row" style="margin-top: 20px;">
                                            <div class="col-md-4">&nbsp;</div>
                                            <div class="col-md-4">
                                                <asp:Label ID="lblHeader" runat="server" ForeColor="Red" Text="Header"></asp:Label>
                                            </div>
                                            <div class="col-md-4">&nbsp;</div>
                                        </div>
                                      <div class="row" style="margin-top: 20px;">
                                            <div class="col-md-4">&nbsp;</div>
                                            <div class="col-md-4">
                                               <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Text="Message"></asp:Label>
                                            </div>
                                            <div class="col-md-4">&nbsp;</div>
                                        </div>
                                      <div class="row" style="margin-top: 20px;">
                                            <div class="col-md-4">&nbsp;</div>
                                            <div class="col-md-4">
                                                <asp:Button ID="btnOk" runat="server" Text="Ok" />
                                               
                                            </div>
                                            <div class="col-md-4">&nbsp;</div>
                                        </div>
                                </asp:View>
                            </asp:MultiView>
                        </div>
                    <div class="col-md-2">&nbsp;</div>
                    </div>


                </td>

            </tr>
        </table>
    </form>
</body>
</html>
