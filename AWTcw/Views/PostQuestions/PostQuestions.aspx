<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<AWTcw.Models.QuestionModel>" %>

<!DOCTYPE html>
<%: Styles.Render("~/Content/css") %>
<%: Scripts.Render("~/bundles/modernizr") %>


  
   
<html>

<body>
   
  <div id="header" style="background-color: #726f6f; height: 70px">
        <div style="width: 100px; margin-left: 1000px; height:25px; margin-top:10px; border-style: solid; background-color: #aea6a6; text-align: center; position:absolute; font-size:larger">
            <%: Html.ActionLink("Log Out","Login","Login")%>
          
        </div>
        <div style="width: 100px; margin-left: 1150px; margin-top:10px; height:25px; border-style: solid; background-color: #aea6a6; text-align:center; position:absolute; font-size:larger"> <%: Html.ActionLink("My Profile","UserProfile","UserProfile")%></div>
      
    </div>
     <div><label style="margin-left:550px; font-size:xx-large">Post Questions</label></div>
    <%using (Html.BeginForm("AddQuestions", "PostQuestions"))
      { %>
        <%: Html.AntiForgeryToken()%>
        <%: Html.ValidationSummary(true)%>
        <%--<div class="validation-summary-errors" style="margin-top: 121px">--%>
        <%--<div id="ac" style="margin-left: 27px; margin-top: 160px; ">--%>
        <fieldset id="ac" style="margin-left: 27px; margin-top: 120px;">
            <legend>Registration Form</legend>
            <ol>
                <li>
                    <div>
                    <%: Html.LabelFor(m => m.Title)%>
                    </div>
                    <%: Html.TextBoxFor(m => m.Title)%>
                    
                    <%: Html.ValidationMessageFor(m => m.Title)%>
                </li>
                <li>
                    <div>
                    <%: Html.LabelFor(m => m.Question)%>
                        </div>
                    <%: Html.TextAreaFor(m => m.Question)%>
                    <%: Html.ValidationMessageFor(m => m.Question)%>
                </li>
                <li>
                    <%: Html.TextBox("tag")%>
                    <%--<input name="tags" id="Text1" value="" hidden="hidden">--%>
                    
                   
                </li>
                 <li>
                     <div>
                    <%: Html.Label("Category")%>
                     </div>
                    <%: Html.DropDownList("t")%>
                </li>
                <%--<li>
                    <%: Html.LabelFor(m => m.Password) %>
                    <%: Html.TextBoxFor(m => m.Password) %>
                    <%: Html.ValidationMessageFor(m => m.Password) %>
                </li>--%>
               
                <%--<li>
                    <%: Html.LabelFor(m => m.ConfirmPassword) %>
                    <%: Html.TextBoxFor(m => m.ConfirmPassword) %>
                    <%: Html.ValidationMessageFor(m => m.ConfirmPassword) %>
                </li>--%>
            </ol>
             
            <input type="submit" value="Post" id="qsubmit">
  
        </fieldset>
         
            <%--</div>--%>
        <% } %>
    <ul id="qwe" >
        
                </ul>
     <input type="submit" id="TagSubmit" value="Pot" hidden="hidden">
    <input name="tags" id="mySingleField" value="" hidden="hidden">
    <%: Scripts.Render("~/bundles/jquery") %>
    <link href="../../Content/jquery.tagit.css" rel="stylesheet" />
<link href="../../Content/tagit.ui-zendesk.css" rel="stylesheet" />

<%--<script src="http://ajax.googleapis.com/ajax/libs/jquery/1.10.2/jquery.min.js" type="text/javascript" charset="utf-8"></script>--%>
<%--<script src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.9.2/jquery-ui.min.js" type="text/javascript" charset="utf-8"></script>--%>
   <script src="../../Scripts/jquery-1.7.1.min.js"></script>
<%--<link rel="stylesheet" type="text/css" href="http://ajax.googleapis.com/ajax/libs/jqueryui/1/themes/flick/jquery-ui.css">--%>
    <%--<script src="http://ajax.googleapis.com/ajax/libs/jquery/1.5.2/jquery.min.js" type="text/javascript" charset="utf-8"></script>--%>
<%--<script src="https://ajax.googleapis.com/ajax/libs/jqueryui/1.8.12/jquery-ui.min.js" type="text/javascript" charset="utf-8"></script>--%>

<script src="../../Scripts/jquery-ui-1.8.20.js"></script>
<script src="../../Scripts/tag-it.js"></script>
    
    <script type="text/javascript">

        $(document).ready(function () {


            //    var items = [];
            //    $.each(data, function (key, val) {
            //        var jsonContent = val.Title;
            //        var content = $("<li id=" + val.QuestionId + "><label>" + "Answers : " + val.NoOfAnswers + "</Label>" + "&nbsp;&nbsp;&nbsp;&nbsp&nbsp;" + "<a id=" + val.QuestionId + " href='Test'>" + jsonContent + "</a></li");
            //        $("#sz").append(content);
            //    });
        });
            $('#qwe').tagit({
                singleField: true,
                singleFieldNode: $('#mySingleField')
            });
            $("#TagSubmit").click(function () {
                $('#qwe').tagit({
                    singleField: true,
                    singleFieldNode: $('#mySingleField')
                });
                var t = $('#mySingleField').val();

                //var t = $("#qwe li").ta;
                //var string;
                //for (var i in t)
                //    string = i.sub+ ",";
                //window.alert(t);

                $.post("/PostQuestions/AddTag", { "tq": t });


            });
            $("#qsubmit").click(function () {
                $("#TagSubmit").show()
            });
            $(document).ready(function () {
                $('#tag').tagit({
                    //singleField: true,
                    //singleFieldNode: $('#mySingleField')
                });
                //window.alert(t);
                //});
                //showTags($('#demo9').tagit('tags'))
                //function showTags(tags)
                //{
                //    var string = "Tags (label : value)\r\n";
                //    string += "--------\r\n";
                //    for (var i in tags)
                //        string += tags[i].label + " : " + tags[i].value + "\r\n";
                //    alert(string);
                //}
            });
            
            
</script>
    <%: Scripts.Render("~/bundles/jquery") %>
    
</body>
</html>
