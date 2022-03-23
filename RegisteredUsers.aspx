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

		.auto-style33 {
			position: relative;
			min-height: 1px;
			float: left;
			width: 100%;
			text-align: right;
			padding-left: 15px;
			padding-right: 15px;
		}
	</style>
</head>
<body>
	<form id="form1" runat="server">
		<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
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
							&nbsp;
						</div>
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
										<%--<div class="row" style="margin-top: 20px;">
											<div class="col-md-2">
												
											</div>
											<div class="col-md-10">
												&nbsp;
											</div>
											
										</div>--%>
										<div class="row" style="margin-top: 20px;">
											<div class="auto-style33">
												<strong>
													<asp:LinkButton ID="lbtnAddNew" runat="server" CssClass="auto-style32" ForeColor="orangered" OnClick="lbtnAddNew_Click">Add User</asp:LinkButton>
												</strong>
												<asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" DataKeyNames="UsrID" DataSourceID="SqlDataSource2">
													<AlternatingRowStyle BackColor="White" ForeColor="#284775" />
													<Columns>
														<asp:TemplateField HeaderText="Select" InsertVisible="False" SortExpression="UsrID">
															<ItemTemplate>
																<asp:LinkButton ID="lbtnSelect" runat="server" CausesValidation="False" OnCommand="Select_Record" CommandArgument='<%# Bind("UsrID") %>'>
												<span style="font-size:medium; color:orangered">Select</span>
																</asp:LinkButton>

															</ItemTemplate>
														</asp:TemplateField>
														<asp:BoundField DataField="ContactID" HeaderText="ContactID" SortExpression="ContactID" Visible="False" />
														<asp:BoundField DataField="Contact" HeaderText="Contact" ReadOnly="True" SortExpression="Contact" />
														<asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
														<asp:CheckBoxField DataField="IsLocked" HeaderText="IsLocked" SortExpression="IsLocked" />
														<asp:BoundField DataField="Password Exp Date" HeaderText="Password Exp Date" SortExpression="Password Exp Date" DataFormatString="{0:dd/MM/yyyy}" />
														<asp:BoundField DataField="Access Level" HeaderText="Access Level" SortExpression="Access Level" />
														<asp:BoundField DataField="User Status" HeaderText="User Status" SortExpression="User Status" />
														<asp:BoundField DataField="CompID" HeaderText="CompID" SortExpression="CompID" Visible="False" />
														<asp:BoundField DataField="Company" HeaderText="Company" SortExpression="Company" />
														<asp:BoundField DataField="Company Status" HeaderText="Company Status" SortExpression="Company Status" />
													</Columns>
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
												<asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:PTSWebConnectionString %>"
													SelectCommand="SELECT [UsrID],[ContactID],[Fname]+' '+ [Lname] as Contact,[Email],[IsLocked],[PswExpDate] as 'Password Exp Date',case when[AccessLvl]=0 then 'User'
												when[AccessLvl]=1 then 'Administrator' end as 'Access Level',case when[Ustatus]=0 then 'Inactive'  when[Ustatus]=1 then 'Active' 
												when[Ustatus]=2 then 'In-Progress' end as 'User Status',[CompID],[CompName]'Company',case when[CompStatus]=0 then 'Inactive'	  
												when[CompStatus]=1 then 'Active' end as 'Company Status' FROM [PTSWeb].[dbo].[tblUser] with (Nolock)"></asp:SqlDataSource>
											</div>
										</div>
									</div>
								</asp:View>
								<asp:View ID="View2" runat="server">
									<div class="container">
										<h4><u>Section Add User</u></h4>
										<div class="row" style="margin-top: 20px;">
											<div class="col-md-4">
												Company:
												<asp:DropDownList ID="ddlCompany" runat="server" DataSourceID="SqlDataSource1" AutoPostBack="True" DataTextField="SponsorName" DataValueField="SponsorID" OnSelectedIndexChanged="ddlCompany_SelectedIndexChanged" Width="250"></asp:DropDownList>
												<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:PTSConnectionString %>"
													SelectCommand="with TT1([SponsorID],[SponsorName]) as (Select 0 'SponsorID',' Select Sponsor'union SELECT [SponsorID],[SponsorName] 
													FROM [PTS].[dbo].[Sponsors] with (Nolock)  where Active=1) Select [SponsorID],[SponsorName] from TT1 order by [SponsorName]"></asp:SqlDataSource>
												<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlCompany" ErrorMessage="Select Company" InitialValue="0">*</asp:RequiredFieldValidator>
											</div>
											<div class="col-md-4">

												<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
													<ContentTemplate>
														Contact:<asp:DropDownList ID="ddlContact" runat="server"></asp:DropDownList>
													</ContentTemplate>
													<Triggers>
														<asp:PostBackTrigger ControlID="ddlCompany" />
													</Triggers>
												</asp:UpdatePanel>
												<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlContact" ErrorMessage="Select Contact">*</asp:RequiredFieldValidator>
											</div>
											<div class="col-md-4">
												Contact Email:<asp:TextBox ID="txtEmail" Width="250px" runat="server"></asp:TextBox>
												<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtEmail" ErrorMessage="Select Email">*</asp:RequiredFieldValidator>
											</div>

										</div>
										<div class="row" style="margin-top: 20px;">
											<div class="col-md-4">
												User Access:
												<asp:RadioButtonList ID="optUserAccess" runat="server" RepeatDirection="Horizontal" RepeatLayout="Table">
													<asp:ListItem Selected="True" Value="0">User</asp:ListItem>
													<asp:ListItem Value="1">Administrator</asp:ListItem>
												</asp:RadioButtonList>
											</div>

											<div class="col-md-4">
												User Status:
												<asp:RadioButtonList ID="optUserStatus" runat="server" RepeatDirection="Horizontal" RepeatLayout="Table">
													<asp:ListItem Value="0">Inactive</asp:ListItem>
													<asp:ListItem Value="1">Active</asp:ListItem>
													<asp:ListItem Selected="True" Value="2">In-Progress</asp:ListItem>
												</asp:RadioButtonList>
											</div>
											<div class="col-md-4">&nbsp;</div>
										</div>
										<hr />
										<div class="row" style="margin-top: 20px;">
											<div class="col-md-12">
												<asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
												<asp:Button ID="btnCancel" runat="server" CausesValidation="False" Text="Cancel" OnClick="btnCancel_Click" />
											</div>
										</div>
									</div>
								</asp:View>
								<asp:View ID="View3" runat="server">
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
												<asp:Button ID="btnOk" runat="server" Text="Close" OnClick="btnOk_Click" />
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
