<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<!DOCTYPE html>
<%: Styles.Render("~/Content/css") %>
<%: Scripts.Render("~/bundles/modernizr") %>
<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>Questions</title>
</head>
<body>
     <div id="header" style="background-color: #726f6f; height: 70px">
        <div style="width: 100px; margin-left: 1000px; height:25px; margin-top:10px; border-style: solid; background-color: #aea6a6; text-align: center; position:absolute; font-size:larger">
            <%: Html.ActionLink("Log Out","Login","Login")%>
           <%--<%: Html.ActionLink("My Profile","UserProfile","UserProfile")%>--%>
        </div>
        <div style="width: 100px; margin-left: 1150px; margin-top:10px; height:25px; border-style: solid; background-color: #aea6a6; text-align:center; position:absolute; font-size:larger"> <%: Html.ActionLink("My Profile","UserProfile","UserProfile")%></div>
       <%-- <p style="width: 80px; margin-left: 1100px; margin-top:0px; border-style: solid; background-color: #aea6a6; text-align: center; position:absolute">
            <%: Html.ActionLink("My Profile","UserProfile","UserProfile")%>
        <%--<link id="profile" href="/UserProfile/UserProfile" rel="next" style="style=width: 80px; margin-left: 1000px;"/>--%>

        <%--</p>--%>
    </div>
    <div><label style="margin-left:550px; font-size:xx-large">Questions</label></div>
        <%  if (((List<AWTcw.Models.QuestionModel>)ViewBag.categoryList) != null)%>
        <%{ %> 
        <ul style="font-size: x-large; margin-left:30px; margin-top:40px;">
     <%foreach (AWTcw.Models.QuestionModel a in ViewBag.categoryList)
                 {%>
        
<li><label>No. Of Answers:&nbsp<%: a.NoOfAnswers %></label>&nbsp;&nbsp;&nbsp;&nbsp<%: Html.ActionLink(a.Title, "ViewAnswers", "ViewAnswers", new { quesid = a.QuestionId },null)%> </li>                
         <%} %>
            </ul>
        <% }%> 
            
    <%if((ViewBag.tagList != null)) {%>
    
    <ul style="font-size: x-large; margin-left:30px; margin-top:40px;">
     <%foreach (AWTcw.Models.QuestionModel a in ViewBag.tagList)
                 {%>
        
<li><label>No. Of Answers:&nbsp<%: a.NoOfAnswers %></label>&nbsp;&nbsp;&nbsp;&nbsp;<%: Html.ActionLink(a.Title, "ViewAnswers", "ViewAnswers", new { quesid = a.QuestionId },null)%> </li>                
         <%} %>
        </ul>
        <%} %>
    <div>
        
    </div>
    <%: Scripts.Render("~/bundles/jquery") %>
</body>
</html>
