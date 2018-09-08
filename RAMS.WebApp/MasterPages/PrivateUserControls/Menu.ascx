<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Menu.ascx.cs" Inherits="Mol.Web.Common.UI.MasterPages.PrivateUserControls.Menu" %>
<%@ Register Src="ManpowerMenu.ascx" TagName="ManpowerMenu" TagPrefix="uc1" %>
<div class="StaticPartsContainer" id="WorkSpace" runat="server">
    <div class="StaticPartsHeader">
        <div class="StaticPartsFooter">
            <div class="AboutMinistry">
                <h3 class="Theme">
                    <asp:HyperLink ID="hlnkDefault" runat="server" Text="منطقة العمل" meta:resourcekey="hlnkDefaultResource"></asp:HyperLink>
                </h3>
            </div>
        </div>
    </div>
</div>
<div id="divManpowerMenu" runat="server">
    <uc1:ManpowerMenu ID="ctrlManpowerMenu" runat="server" Visible="false" />
</div>
<div class="StaticPartsContainer" id="divEstablishments" runat="server">
    <div class="StaticPartsHeader">
        <div class="StaticPartsFooter">
            <div class="AboutMinistry">
                <h3>
                    <asp:Label runat="server" ID="label43" Text="المنشآت" meta:resourcekey="label43Resource1"></asp:Label>
                </h3>
                <ul>
                    <li>
                        <asp:HyperLink ID="hlnkMyCompanies" runat="server" Text="البحث عن منشأة" meta:resourcekey="hlnkMyCompaniesResource"></asp:HyperLink></li>
                    <li>
                        <asp:HyperLink ID="hlnkLaborers" runat="server" Text="البحث عن عامل " meta:resourcekey="hlnkLaborersResource"></asp:HyperLink></li>
                </ul>
            </div>
        </div>
    </div>
</div>
<div class="StaticPartsContainer" id="divCIWServices" runat="server">
    <div class="StaticPartsHeader">
        <div class="StaticPartsFooter">
            <div class="AboutMinistry">
                <h3>
                    <asp:Label ID="Label4" runat="server" Text="الخدمات" meta:resourcekey="Label4Resource1"></asp:Label>
                </h3>
                <ul>
                    <li>
                        <asp:HyperLink ID="hlnkTransactions" runat="server" Text="البحث عن طلب رخصة عمل"
                            meta:resourcekey="hlnkTransactionsResource"></asp:HyperLink></li>
                    <li>
                        <asp:HyperLink ID="hlnkCompaniesSearch" runat="server" Text="طلب رخصة عمل لمنشأة "
                            meta:resourcekey="hlnkCompaniesSearchResource"></asp:HyperLink></li>
                </ul>
            </div>
        </div>
    </div>
</div>
<div class="StaticPartsContainer" id="divIndividual" runat="server">
    <div class="StaticPartsHeader">
        <div class="StaticPartsFooter">
            <div class="AboutMinistry">
                <h3>
                    <asp:Label ID="Label7" runat="server" Text="إدارة مستخدمي النظام" meta:resourcekey="Label7Resource1"></asp:Label>
                </h3>
                <ul>
                    <li>
                        <asp:HyperLink ID="hlnkRolesManagement" runat="server" Text="إدارة الوظائف" meta:resourcekey="hlnkRolesManagementResource"></asp:HyperLink>
                    </li>
                    <li>
                        <asp:HyperLink ID="hlnkInternalEmployees" runat="server" Text="قائمة الموظفين" meta:resourcekey="hlnkInternalEmployeesResource"></asp:HyperLink>
                    </li>
                    <li runat="server" id="liIndividual">
                        <asp:HyperLink ID="hlnkIndividualAdmin" runat="server" Text="تعديل بيانات المستخدمين"
                            meta:resourcekey="hlnkIndividualAdminResource"></asp:HyperLink>
                    </li>
                </ul>
            </div>
        </div>
    </div>
</div>
<div id="PublicMenu" runat=server>
<div class="StaticPartsContainer" style='display:none;'>
    <div class="StaticPartsHeader">
        <div class="StaticPartsFooter">
            <div class="AboutMinistry">
                <h3 class="Theme">
                <a href="/sites/default.aspx">الصفحة الرئيسية</a>
                </h3>
            </div>
        </div>
    </div>
</div>

<div class="StaticPartsContainer" style='display:none;'>
    <div class="StaticPartsHeader">
        <div class="StaticPartsFooter">
            <div class="AboutMinistry">
                <h3 class="Theme">
                <a href="/SecureSSL/EUlogin.aspx">دخول المنشاّت المسجلة</a>
                </h3>
            </div>
        </div>
    </div>
</div>
<div class="StaticPartsContainer" style='display:none;'>
    <div class="StaticPartsHeader">
        <div class="StaticPartsFooter">
            <div class="AboutMinistry">
                <h3 class="Theme">
                    <asp:Label ID="lblEservices" runat="server" Text="للمنشاّت الغير مسجلة" ></asp:Label>
                </h3>
                <ul>
                    <li>
                        <a href="/securessl/publiclogin.aspx">خدمة رخصة العمل</a>
                    </li>
                </ul>
            </div>
        </div>
    </div>
</div>

<div class="StaticPartsContainer" style='display:none;'>
    <div class="StaticPartsHeader">
        <div class="StaticPartsFooter">
            <div class="AboutMinistry">
                <h3 class="Theme">
                <a href="/securessl/publiclogin.aspx">تقييم المنشاّت</a>
                </h3>
            </div>
        </div>
    </div>
</div>

<div class="StaticPartsContainer">
    <div class="StaticPartsHeader">
        <div class="StaticPartsFooter">
            <div class="AboutMinistry">
                <h3 class="Theme">
                    <asp:Label ID="lblInquiry" runat="server" Text="الاستعلامات الإلكترونية" ></asp:Label>
                </h3>
                <ul>
                    <li>
                        <a href="/Services/Inquiry/SaudiEmpInquiry.aspx">الاستعلام عن موظف سعودي</a>
                    </li>
                    <li>
                        <a href="/Services/Inquiry/NonSaudiEmpInquiry.aspx">الاستعلام عن موظف وافد</a>
                    
                        
                        
                        </li>
                        <li><a href="/Services/Inquiry/LaborOfficeServicesInquiry.aspx">الاستعلام عن خدمات مكتب
                            العمل</a> </li>
                        <li><a href="/Services/Inquiry/CompanyMainInfoInquiry.aspx">الاستعلام عن البيانات الرئيسية
                            لمنشأة</a> </li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
</div>
