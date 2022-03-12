<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebMaintenance.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Log-in</title>
    <%-- <webopt:BundleReference runat="server" Path="~/Content/css" />--%>
    <%-- <link href="Content/bootstrap-theme.css" rel="stylesheet" />
    <link href="Content/bootstrap-theme.min.css" rel="stylesheet" />--%>
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="css/style.css" rel="stylesheet" />
    <link href="css/My_Style.css" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server">
        <table class="borderless" style="width: 1200px;">
            <tr>
                <th> <%--style="align-items: center; vertical-align: middle; width: 99%; border: none;"--%>
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
                        <div class="col-md-2">&nbsp;</div>
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
                                    <div class="row" style="margin-top: 20px;">
                                        <div class="col-md-2">
                                            <asp:Label ID="Label16" runat="server" Font-Bold="True" ForeColor="#F15A22" Text="Email:" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUserEmail"
                                                ErrorMessage="Email">*</asp:RequiredFieldValidator>
                                        </div>
                                        <div class="col-md-4">
                                            <asp:TextBox ID="txtUserEmail" runat="server" Width="250px" />
                                        </div>
                                        <div class="col-md-6">
                                            
                                        </div>
                                    </div>
                                    <div class="row" style="margin-top: 20px;">
                                        <div class="col-md-2">
                                            <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="#F15A22" Text="Password:" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPsw" ErrorMessage="Password">*</asp:RequiredFieldValidator>
                                        </div>
                                        <div class="col-md-4">
                                            <asp:TextBox ID="txtPsw" runat="server" Width="250px" TextMode="Password" />
                                        </div>
                                        <div class="col-md-6">
                                            
                                        </div>
                                    </div>
                                    <div class="row" style="margin-top: 20px;">
                                        <div class="col-md-2"></div>
                                        <div class="col-md-4">
                                            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                                            <asp:Button ID="btnCancel" runat="server" CausesValidation="False" Text="Cancel" UseSubmitBehavior="False" OnClick="btnCancel_Click" />
                                        </div>
                                        <div class="col-md-6"></div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-12">
                                            <asp:Image ID="Image3" runat="server" BorderWidth="0px" ImageUrl="~/img/forgot_pw.png" />
                                            <asp:LinkButton ID="lbtnForgotPsw" runat="server" CausesValidation="False" ForeColor="#0066CC" OnClick="lbtnForgotPsw_Click">Forgot Password</asp:LinkButton>
                                        </div>
                                    </div>


                                </asp:View>
                                <asp:View ID="View2" runat="server">
                                    <table style="width: 100%;">
                                        <tr align="center">
                                            <td>
                                                <asp:Label ID="Label7" runat="server" Font-Bold="True" ForeColor="Red" Text="The ID and/or Password is incorrect.<br/> Please try again  or click 'Forgot Password' below."></asp:Label>
                                            </td>
                                        </tr>
                                        <tr align="center">
                                            <td>
                                                <asp:Button ID="btnForgetClose" runat="server" CausesValidation="False" Text="Cancel" />
                                            </td>
                                        </tr>
                                    </table>
                                </asp:View>
                                <asp:View ID="View3" runat="server">
                                    <table style="width: 100%;">
                                        <tr align="center">
                                            <td>
                                                <asp:Label ID="Label2" runat="server" Font-Bold="True" ForeColor="Red" Text="You’ve reached the maximum logon attempts.<br/> Please contact administrator."></asp:Label>
                                            </td>
                                        </tr>
                                        <tr align="center">
                                            <td>
                                                <asp:Button ID="Button1" runat="server" CausesValidation="False" Text="Cancel" />
                                            </td>
                                        </tr>
                                    </table>
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
