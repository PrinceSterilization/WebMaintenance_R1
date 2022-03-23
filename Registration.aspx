<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="WebMaintenance.Registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>Registration via Email</title>
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
									<div class="container">
										
										<%--<div class="row" style="margin-top: 20px;">
											<div class="col-md-12">
												<asp:Label ID="Label4" runat="server" Font-Bold="True" Text="User" CssClass="auto-style32" />
											</div>
										</div>--%>
										<div class="row" style="margin-top: 20px;">
											<div class="col-md-12">
												<h4><u>User</u></h4>
												<asp:Label ID="lblUserName" runat="server" Font-Bold="True" ForeColor="#F15A22" Text="First, Last name" />
											</div>
										</div>
										<hr />
										
										<div class="row" style="margin-top: 20px;">
											<div class="col-md-12">
												<%--<asp:Label ID="lblHeaderQA" runat="server" Font-Bold="True" Text="Section Q & A" CssClass="auto-style32" />--%>
												<h4><u>Section Q & A</u></h4>
											</div>
										</div>
										<div class="row" style="margin-top: 20px;">
											<div class="col-md-4">
												Q1:<asp:DropDownList ID="ddlQ1" runat="server" DataSourceID="SqlDataSource1" DataTextField="Question" DataValueField="QID"></asp:DropDownList>
												<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlQ1" ErrorMessage="Question 1" InitialValue="0">*</asp:RequiredFieldValidator>
												<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:PTSWebConnectionString %>" SelectCommand="with TT1([QID]
													,[Question],[Qorder],[Qstatus]) as (SELECT 0 as[QID],'Select Question'[Question],0 as[Qorder],1 as [Qstatus]
													 union
													SELECT [QID],[Question],[Qorder],[Qstatus] FROM [PTSWeb].[dbo].[ctrlQuestions] with(Nolock))
													Select [QID],[Question],[Qorder],[Qstatus] from TT1 where ([Qstatus]=@Qstatus) ORDER BY [Qorder]">
													<SelectParameters>
														<asp:Parameter DefaultValue="1" Name="Qstatus" Type="Int32" />
													</SelectParameters>
												</asp:SqlDataSource>
												
											</div>
											<div class="col-md-4">
												A1:
											<asp:TextBox ID="txtA1" runat="server" Width="250px" />
												<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtA1" ErrorMessage="A1">*</asp:RequiredFieldValidator>
											</div>
											<div class="col-md-4">&nbsp;</div>
										</div>
										<div class="row" style="margin-top: 20px;">
											<div class="col-md-4">
												Q2:<asp:DropDownList ID="ddlQ2" runat="server" DataSourceID="SqlDataSource1" DataTextField="Question" DataValueField="QID"></asp:DropDownList>
												<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddlQ2" ErrorMessage="Question 2" InitialValue="0">*</asp:RequiredFieldValidator>
												
											</div>
											<div class="col-md-4">
												A2:
											<asp:TextBox ID="txtA2" runat="server" Width="250px" />
												<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtA2" ErrorMessage="A2">*</asp:RequiredFieldValidator>
											</div>
											<div class="col-md-4">&nbsp;</div>
										</div>
										<div class="row" style="margin-top: 20px;">
											<div class="col-md-4">
												Q3:<asp:DropDownList ID="ddlQ3" runat="server" DataSourceID="SqlDataSource1" DataTextField="Question" DataValueField="QID"></asp:DropDownList>
												<asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="ddlQ3" ErrorMessage="Question 3" InitialValue="0">*</asp:RequiredFieldValidator>
												
											</div>
											<div class="col-md-4">
												A3:
											<asp:TextBox ID="txtA3" runat="server" Width="250px" />
												<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtA3" ErrorMessage="A3">*</asp:RequiredFieldValidator>
											</div>
											<div class="col-md-4">&nbsp;</div>
										</div>
										<hr />
										<%--<h4><u>Section Update Password</u></h4>--%>
										<div class="row" style="margin-top: 20px;">
											<div class="col-md-12">
												<%--<asp:Label ID="Label3" runat="server" Font-Bold="True" Text="Section Update Password" CssClass="auto-style32" />--%>
												<h4>Section Update Password</h4>
											</div>
										</div>
										<div class="row" style="margin-top: 20px;">
											<div class="col-md-4">
												<asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="#F15A22" Text="New Password:" />
												<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtNewPassword"
													ErrorMessage="Email">*</asp:RequiredFieldValidator>
											</div>
											<div class="col-md-4">
												<asp:TextBox ID="txtNewPassword" runat="server" Width="250px" TextMode="Password" />
											</div>
											<div class="col-md-4">&nbsp;</div>
										</div>
										<div class="row" style="margin-top: 20px;">
											<div class="col-md-4">
												<asp:Label ID="Label2" runat="server" Font-Bold="True" ForeColor="#F15A22" Text="Confirm Password:" />
												<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtNewPassword2"
													ErrorMessage="Email">*</asp:RequiredFieldValidator>
											    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtNewPassword" ControlToValidate="txtNewPassword2" ErrorMessage="Password must match" ForeColor="Red"></asp:CompareValidator>
											</div>
											<div class="col-md-4">
												<asp:TextBox ID="txtNewPassword2" runat="server" Width="250px" TextMode="Password" />
											</div>
											<div class="col-md-4">&nbsp;</div>
										</div>
										<div class="row" style="margin-top: 20px;">
											<div class="col-md-4">&nbsp;</div>
											<div class="col-md-4">
												<asp:Button ID="btnUpdatePsw" runat="server" Text="Update Password" OnClick="btnUpdatePsw_Click" />
												<asp:Button ID="btnCancelUpdate" runat="server" CausesValidation="False" Text="Cancel" OnClick="btnCancelUpdate_Click" />
											</div>
											<div class="col-md-4">&nbsp;</div>
										</div>
									</div>
								</asp:View>
								<asp:View ID="View2" runat="server">
									 <div class="container">
										<div class="row" style="margin-top: 20px;">
											<div class="col-md-12">
												<h3>
													<asp:Label ID="lblHeader" runat="server" ForeColor="Red" Text="Header" />
												</h3>
											</div>
										</div>
										<div class="row" style="margin-top: 20px;">
											<div class="col-md-12">
												<p>
													<asp:Label ID="lblMessage" runat="server" ForeColor="Red" Text="Message" />
												</p>
											</div>
										</div>
										<div class="row" style="margin-top: 20px;">
											<div class="col-md-12">
												<asp:Button ID="btnClose" runat="server" Text="Close" OnClick="btnClose_Click"  />
											</div>
										</div>
									</div>
								</asp:View>
							</asp:MultiView>
						</div>
						<div class="col-md-2">&nbsp;</div>
					</div>
					<div class="container body-content">
						<div class="row" style="align-items: center;">
							<div class="col-md-2">&nbsp;</div>
							<div class="col-md-8" style="align-content: center; align-items: center; align-self: center;">
								<hr />
								<p>&copy; <%: DateTime.Now.Year %> - Web Maintenance Application</p>
							</div>
							<div class="col-md-2">&nbsp;</div>
						</div>
					</div>
				</td>

			</tr>
		</table>
		<input id="hdnAction" runat="Server" type="hidden" />
		<input id="hdnErrorID" runat="Server" type="hidden" />
		<input id="hdnUsrID" runat="Server" type="hidden" />
	</form>
</body>
</html>
