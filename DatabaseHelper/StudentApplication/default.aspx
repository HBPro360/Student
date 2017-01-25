<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="StudentApplication._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style2 {
            width: 343px;
        }

        .auto-style3 {
            width: 343px;
            height: 23px;
        }

        .auto-style4 {
            height: 23px;
        }

        .auto-style5 {
            width: 343px;
            height: 30px;
        }

        .auto-style6 {
            height: 30px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table style="width: 100%">

                <tr>

                    <td class="auto-style2">
                        <asp:TextBox ID="txtFirstName" placeholder="First Name" runat="server"></asp:TextBox><br />
                        <asp:TextBox ID="txtLastName" placeholder="Last Name" runat="server"></asp:TextBox><br />
                        <asp:TextBox ID="txtEmail" placeholder="Email" runat="server"></asp:TextBox><asp:DropDownList 
                            ID="ddlEmailType" runat="server" DataTextField="Email" DataValueField="ID"></asp:DropDownList><br />
                        <asp:TextBox ID="txtPassword" placeholder="Password" runat="server"></asp:TextBox><br />
                        <br />
                        <asp:DropDownList ID="ddlPhoneType" runat="server" DataTextField="Type" DataValueField="ID"></asp:DropDownList><br />
                        <asp:TextBox ID="txtNumber" placeholder="Phone Number" runat="server"></asp:TextBox><br />
                        <br />
                        
                    </td>
                    <td>
                        <div style="height: 250px; width: auto; overflow: auto">
                            <asp:GridView ID="gvStudent" runat="server" AutoGenerateColumns="false" OnSelectedIndexChanged="gvStudent_SelectedIndexChanged">
                                <Columns>
                                    <%--<asp:BoundField DataField="FullName" HeaderText="Name" />
                            <asp:BoundField DataField="Email" HeaderText="Email" />
                            <asp:BoundField DataField="Password" HeaderText="Password" />
                            <asp:BoundField DataField="LastUpdated" HeaderText="Last Updated" />--%>
                                    <%--HeaderText="Edit" ShowHeader="false" ItemStyle-Width="100px"--%>
                                    <%--<asp:ButtonField ButtonType="Link" runat="server" CommandName="AddPhone" Text="Add Phone" />--%>
                                    <asp:TemplateField HeaderText="Phone" ShowHeader="true">
                                        <ItemTemplate>
                                            <asp:Button ID="btnShowPhone" runat="server" Text="Show Phone" CommandName="ShowPhone" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Phone" ShowHeader="true">
                                        <ItemTemplate>
                                            <asp:Button ID="btnAddPhone" runat="server" Text="Add Phone" CommandName="AddPhone" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Email" ShowHeader="true">
                                        <ItemTemplate>
                                            <asp:Button ID="btnShowEmail" runat="server" Text="Show Email" CommandName="ShowEmail" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Email" ShowHeader="true">
                                        <ItemTemplate>
                                            <asp:Button ID="btnAddEmail" runat="server" Text="Add Email" CommandName="AddEmail" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" ShowHeader="false" ItemStyle-Width="50px">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnedit" runat="server" CommandName="Edit" Text="Edit"></asp:LinkButton>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:LinkButton ID="btnupdate" runat="server" CommandName="Update" Text="Update"></asp:LinkButton>
                                            <asp:LinkButton ID="btnCancel" runat="server" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="First Name" ShowHeader="false" ItemStyle-Width="100px">
                                        <ItemTemplate>
                                            <asp:Label ID="lblFirstName" runat="server" CommandName="Edit" Text='<%# DataBinder.Eval(Container.DataItem, "FirstName")%>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtFirstName" runat="server" CommandName="Update" Text='<%# DataBinder.Eval(Container.DataItem, "FirstName")%>'></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Last Name" ShowHeader="false" ItemStyle-Width="100px">
                                        <ItemTemplate>
                                            <asp:Label ID="lblLastName" runat="server" CommandName="Edit" Text='<%# DataBinder.Eval(Container.DataItem, "LastName")%>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtLastName" runat="server" CommandName="Update" Text='<%# DataBinder.Eval(Container.DataItem, "LastName")%>'></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Email" ShowHeader="false" ItemStyle-Width="100px">
                                        <ItemTemplate>
                                            <asp:Label ID="lblEmail" runat="server" CommandName="Edit" Text='<%# DataBinder.Eval(Container.DataItem, "Email")%>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtEmail" runat="server" CommandName="Update" Text='<%# DataBinder.Eval(Container.DataItem, "Email")%>'></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Password" ShowHeader="false" ItemStyle-Width="100px">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPassword" runat="server" CommandName="Edit" Text='<%# DataBinder.Eval(Container.DataItem, "Password")%>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtPassword" runat="server" CommandName="Update" Text='<%# DataBinder.Eval(Container.DataItem, "Password")%>'></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:DropDownList ID="ddlprograms" runat="server" DataTextField="Name" DataValueField="ID" Enabled="false">
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:DropDownList ID="ddlprograms" runat="server" DataTextField="Name" DataValueField="ID" Enabled="true">
                                            </asp:DropDownList>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" ShowHeader="false" ItemStyle-Width="50px">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btndelete" runat="server" CommandName="Delete" Text="Delete" OnClientClick="return confirm('Are you sure?');"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </td>
                </tr>
                <tr>

                    <td id="btnSave" class="auto-style5">
                        <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
                    </td>
                    <td class="auto-style6"></td>
                </tr>

                <tr>

                    <td id="btnSave" class="auto-style2">&nbsp;</td>
                    <td>
                        <asp:GridView ID="gvStudentPhones" runat="server" AutoGenerateColumns="False">
                            <Columns>
                                <asp:BoundField DataField="FullName" HeaderText="Name" ReadOnly="true"/>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:Label ID="lblPhone" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Phone")%>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtPhone" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Phone")%>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemStyle Width="100px" />
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:DropDownList ID="ddlPhoneType" runat="server" DataTextField="Type" DataValueField="ID" Enabled="false">
                                        </asp:DropDownList>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="ddlPhoneType" runat="server" DataTextField="Type" DataValueField="ID" Enabled="true">
                                        </asp:DropDownList>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <asp:Gridview ID="gvStudentEmails" runat="server" AutoGenerateColumns="false">
                            <Columns>
                                <asp:BoundField DataField="FullName" HeaderText="Name" ReadOnly="true"/>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:Label ID="lblEmail" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Email")%>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtEmail" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Email")%>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemStyle Width="100px" />
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:DropDownList ID="ddlEmailType" runat="server" DataTextField="Email" DataValueField="ID" Enabled="false">
                                        </asp:DropDownList>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="ddlEmailType" runat="server" DataTextField="Email" DataValueField="ID" Enabled="true">
                                        </asp:DropDownList>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:Gridview>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>

            </table>
        </div>
        <table style="width: 100%; visibility: hidden">
            <tr>

                <td class="auto-style3"></td>
                <td class="auto-style4"></td>
            </tr>
            <tr>

                <td class="auto-style2">
                    <asp:TextBox ID="txtName" placeholder="Program Name" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:GridView ID="gvProgram" runat="server" AutoGenerateColumns="false">
                        <Columns>
                            <asp:TemplateField HeaderText="Edit" ShowHeader="false" ItemStyle-Width="100px">
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnedit" runat="server" CommandName="Edit" Text="Edit"></asp:LinkButton>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:LinkButton ID="btnupdate" runat="server" CommandName="Update" Text="Update"></asp:LinkButton>
                                    <asp:LinkButton ID="btnCancel" runat="server" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Label ID="lblName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Name")%>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtName" runat="server" Text='<%# Bind("Name")%>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemStyle Width="200px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Delete" ShowHeader="false" ItemStyle-Width="50px">
                                <ItemTemplate>
                                    <asp:LinkButton ID="btndelete" runat="server" CommandName="Delete" Text="Delete"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr>

                <td class="auto-style2">
                    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Program" />
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </form>
</body>
</html>
