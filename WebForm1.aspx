<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="SearchTextIntoImage.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    Upload the Image : <asp:FileUpload ID="FileUpload1" AllowMultiple="true" runat="server" /><br /><br />
    </div>
        <p>
        <asp:Button ID="Upload" runat="server" Text="Upload" OnClick="Upload_Click" Width="128px" />
        </p>
        <p>
           
          
            <hr /><hr /><br />
        </p>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                  <asp:Label ID="show" runat="server" Text=""></asp:Label>
              <asp:Timer ID="Timer1" runat="server" Interval="600" OnTick="Timer1_Tick"></asp:Timer>
               
                <center>
                    <asp:GridView ID="GridView2" runat="server" Width="1000px" AutoGenerateColumns="False"  CellPadding="4" DataKeyNames="fpath1" DataSourceID="SqlDataSource2" ForeColor="#333333" GridLines="None" OnRowCommand="GridView2_RowCommand" OnRowDataBound="GridView2_RowDataBound" Caption="Image Information">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="imgId" HeaderText="Id" InsertVisible="False" SortExpression="imgId" ReadOnly="True" />
                            <asp:BoundField DataField="Name1" HeaderText="Name" SortExpression="Name1" />
                            <asp:BoundField DataField="fpath1" HeaderText="Path" SortExpression="fpath1" />
                            <asp:ImageField DataImageUrlField="UploadImage5" HeaderText="Image" ControlStyle-Width="100px" ControlStyle-Height="100px">
                                <ControlStyle Height="100px" Width="100px" />
                            </asp:ImageField>
                            <asp:TemplateField HeaderText="Fetch text Button" >
                                <ItemTemplate>
                                    <asp:Button ID="btnFetchText1" runat="server" Text="FetchText" CommandName="FetchText1" CommandArgument='<%# Container.DataItemIndex %>' BackColor="#CCCCCC" BorderColor="White" BorderStyle="Double" BorderWidth="5px" Font-Size="Large" ForeColor="#006600"  />
                                </ItemTemplate>
                                </asp:TemplateField>
                            <asp:TemplateField HeaderText="Showtext">
                                <ItemTemplate>
                                    <asp:Label ID="lblFetchedText1" runat="server" Text='<%# Eval("Showtext2") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EditRowStyle BackColor="#7C6F57" />
                        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#E3EAEB" />
                        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F8FAFA" />
                        <SortedAscendingHeaderStyle BackColor="#246B61" />
                        <SortedDescendingCellStyle BackColor="#D4DFE1" />
                        <SortedDescendingHeaderStyle BackColor="#15524A" />
                    </asp:GridView>
                    <br />
                   
                    <br />
                </center>
                
          <hr /><hr />
               
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [FileInfo5]"></asp:SqlDataSource>
              <asp:TextBox ID="txtshow" runat="server" Visible="False"></asp:TextBox>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
