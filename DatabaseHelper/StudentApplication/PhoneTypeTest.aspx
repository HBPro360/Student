<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PhoneTypeTest.aspx.cs" Inherits="StudentApplication.PhoneTypeTest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table>
        <tr>
            <td width="200px">
                <asp:TextBox ID="txtType" placeholder="Phone Type" runat="server" Width="150px" align="center"></asp:TextBox>
                <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Insert Phone" />
            </td>
            <td>
                <asp:Gridview ID="gvPhoneType" runat="server" AutoGenerateColumns="false" Width="200px">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="btnEdit" runat="server" CommandName="Edit" Text="Edit" align="center"></asp:LinkButton>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:LinkButton ID="btnUpdate" runat="server" CommandName="Update" Text="Update"></asp:LinkButton>
                                <asp:LinkButton ID="btnCancel" runat="server" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label ID="lblPhoneType" runat="server" CommandName="Edit" Text='<%# DataBinder.Eval(Container.DataItem, "Type") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                    <asp:TextBox ID="txtType" runat="server" CommandName="Update" Text='<%# DataBinder.Eval(Container.DataItem, "Type")%>'></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete" Text="Delete"></asp:LinkButton>
                                </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:Gridview>
            </td>
        </tr>
    </table>
    </div>
    </form>
</body>
</html>
