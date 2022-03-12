<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgotPsw.aspx.cs" Inherits="WebMaintenance.ForgotPsw" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Forgot Password</title>
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
                                        <div class="col-md-12">
                                            <asp:Label ID="Label4" runat="server" Font-Bold="True" ForeColor="#F15A22" Text="Validate Email" CssClass="auto-style32" />
                                        </div>
                                    </div>
                                    <div class="row" style="margin-top: 20px;">
                                        <div class="col-md-2">
                                            <asp:Label ID="Label16" runat="server" Font-Bold="True" ForeColor="#F15A22" Text="Your Email:" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUserEmail"
                                                ErrorMessage="Email">*</asp:RequiredFieldValidator>
                                        </div>
                                        <div class="col-md-4">
                                            <asp:TextBox ID="txtUserEmail" runat="server" Width="250px" />
                                        </div>
                                        <div class="col-md-6">
                                            <asp:Button ID="btnSubmit" runat="server" Text="Validate Email" />
                                            <asp:Button ID="btnCancel" runat="server" CausesValidation="False" Text="Cancel" UseSubmitBehavior="False" OnClick="btnCancel_Click" />
                                        </div>
                                    </div>
                                </asp:View>

                                <asp:View ID="View2" runat="server">
                                    <div class="row" style="margin-top: 20px;">
                                        <div class="col-md-12">
                                            <asp:Label ID="lblHeaderQA" runat="server" Font-Bold="True" ForeColor="#F15A22" Text="Section Q & A" CssClass="auto-style32" />
                                        </div>
                                    </div>
                                    <div class="row" style="margin-top: 20px;">
                                        <div class="col-md-6">
                                            Q1:
                                            <asp:Label ID="lblQ1" runat="server" Font-Bold="True" ForeColor="#F15A22" Text="Question 1" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtA1" ErrorMessage="A1">*</asp:RequiredFieldValidator>
                                        </div>
                                        <div class="col-md-6">
                                            A1:
                                            <asp:TextBox ID="txtA1" runat="server" Width="250px" />
                                        </div>
                                    </div>
                                    <div class="row" style="margin-top: 20px;">
                                        <div class="col-md-6">
                                            Q2:
                                            <asp:Label ID="lblQ2" runat="server" Font-Bold="True" ForeColor="#F15A22" Text="Question 2" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtA2" ErrorMessage="A2">*</asp:RequiredFieldValidator>
                                        </div>
                                        <div class="col-md-6">
                                            A2:
                                            <asp:TextBox ID="txtA2" runat="server" Width="250px" />
                                        </div>
                                    </div>
                                    <div class="row" style="margin-top: 20px;">
                                        <div class="col-md-6">
                                            Q3:
                                            <asp:Label ID="lblQ3" runat="server" Font-Bold="True" ForeColor="#F15A22" Text="Question 3" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtA3" ErrorMessage="A3">*</asp:RequiredFieldValidator>
                                        </div>
                                        <div class="col-md-6">
                                            A3:
                                            <asp:TextBox ID="txtA3" runat="server" Width="250px" />
                                        </div>
                                    </div>
                                    <div class="row" style="margin-top: 20px;">
                                        <div class="col-md-12">
                                            <asp:Button ID="btnSubmitAnswer" runat="server" Text="Submit Answer" />
                                            <asp:Button ID="btnForgetClose" runat="server" CausesValidation="False" Text="Cancel" />
                                        </div>
                                    </div>
                                </asp:View>
                                <asp:View ID="View3" runat="server">
                                    <div class="row" style="margin-top: 20px;">
                                        <div class="col-md-12">
                                            <asp:Label ID="Label3" runat="server" Font-Bold="True" ForeColor="#F15A22" Text="Section Update Password" CssClass="auto-style32" />
                                        </div>
                                    </div>
                                    <div class="row" style="margin-top: 20px;">
                                        <div class="col-md-2">
                                            <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="#F15A22" Text="New Email:" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtNewPassword"
                                                ErrorMessage="Email">*</asp:RequiredFieldValidator>
                                        </div>
                                        <div class="col-md-4">
                                            <asp:TextBox ID="txtNewPassword" runat="server" Width="250px" />
                                        </div>
                                        <div class="col-md-6">
                                        </div>
                                    </div>
                                    <div class="row" style="margin-top: 20px;">
                                        <div class="col-md-2">
                                            <asp:Label ID="Label2" runat="server" Font-Bold="True" ForeColor="#F15A22" Text="Confirm Email:" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtNewPassword2"
                                                ErrorMessage="Email">*</asp:RequiredFieldValidator>
                                        </div>
                                        <div class="col-md-4">
                                            <asp:TextBox ID="txtNewPassword2" runat="server" Width="250px" />
                                        </div>
                                        <div class="col-md-6">
                                        </div>
                                        <div class="row" style="margin-top: 20px;">
                                            <div class="col-md-2">&nbsp;
                                        </div>
                                            <div class="col-md-10">
                                                <asp:Button ID="btnUpdatePsw" runat="server" Text="Update Password" />
                                                <asp:Button ID="btnCancelUpdate" runat="server" CausesValidation="False" Text="Cancel" />
                                            </div>
                                        </div>
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
