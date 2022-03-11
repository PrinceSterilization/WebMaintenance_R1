<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebMaintenance._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    

    <div class="row">
        <div class="col-md-8"><h4>Instructions</h4>
            <p>Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.</p>

        </div>

        <div class="col-md-4">
            <asp:MultiView ID="MultiView1" runat="server">
                <asp:View ID="View1" runat="server">
                    <table style="width: 100%">
                        <tr>
                            <td colspan="2">&nbsp;<asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" />
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label16" runat="server" Font-Bold="True" ForeColor="#F15A22" Text="Email:"></asp:Label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUserEmail"
                                    ErrorMessage="Email">*</asp:RequiredFieldValidator></td>
                            <td>
                                <asp:TextBox ID="txtUserEmail" runat="server" CssClass="textboxes"/></td>
                        </tr>
                        <tr>
                            <td colspan="2">&nbsp;&nbsp;</td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label17" runat="server" Font-Bold="True" ForeColor="#F15A22" Text="Password:"></asp:Label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPsw"
                                    ErrorMessage="Password">*</asp:RequiredFieldValidator></td>
                            <td>
                                <asp:TextBox ID="txtPsw" runat="server" CssClass="textboxes" TextMode="Password"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td colspan="2">&nbsp;&nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2">&nbsp;<asp:Button ID="btnSubmit" runat="server"  Text="Submit" OnClick="btnSubmit_Click" />
                                <asp:Button ID="btnCancel" runat="server" CausesValidation="False" Text="Cancel" UseSubmitBehavior="False" OnClick="btnCancel_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">&nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2">
                                <asp:Image ID="Image3" runat="server" BorderWidth="0px" ImageUrl="~/img/forgot_pw.png" />
                                <asp:LinkButton ID="lbtnForgotPsw" runat="server" CausesValidation="False" ForeColor="#0066CC" OnClick="lbtnForgotPsw_Click">Forgot Password</asp:LinkButton>                                
                                &nbsp;</td>
                        </tr>
                    </table>
                    &nbsp;
                </asp:View>
                <asp:View ID="View2" runat="server">
                    <table style="width: 100%;">
                        <tr align="center">
                            <td>
                                <asp:Label ID="Label7" runat="server" Font-Bold="True" ForeColor="Red" Text="The ID and/or Password is incorrect.<br/> Please try again."></asp:Label>
                            </td>
                        </tr>
                        <tr align="center">
                            <td>
                                <asp:Button ID="btnForgetClose" runat="server" CausesValidation="False" Text="Cancel" OnClick="btnForgetClose_Click" />
                            </td>
                        </tr>
                    </table>
                </asp:View>               
            </asp:MultiView>
        </div>
    </div>

</asp:Content>
