// JavaScript Document
// To hide and show Cc
$(document).ready(function () {
    // BindEvent();
});
function BindEvent() {
    $("#BccTxt").hide();
    $("#CcTxt").hide();
    $("#Cc").click(function () {
        $("#CcTxt").toggle(500, "linear");
        //alert("gd");
    });
    $("#Bcc").click(function () {
        $("#BccTxt").toggle(500, "linear");
        //	alert("gd");
    });


    // Add Folder Form
    $(".folder").click(function () {
        $(".modal-backdrop").hide();
    });

    $(".AddFolder1").click(function () {
        // alert("gd");
        //$(this).parent().find(".AddFolderForm").slideToggle(500, "linear");
        $("#lblPathFolder").text($(this).attr("dir"));
        $("#hdPath").attr("value", $(this).attr("dir"));
        $("#AddFolder").show();
        $("#AddFile").hide();
        $("#DeleteFile").hide();
        //		alert($("#ContentPlaceHolder1_txtFolderName").text());
    });
    // Add File Form


    $(".AddFile1").click(function () {
        $("#lblFilePath").text($(this).attr("dir"));
        $("#hdPath").attr("value", $(this).attr("dir"));
        $("#AddFolder").hide();
        $("#DeleteFile").hide();
        $("#AddFile").show();
      //  alert($(this).parent().find("div").html());
       // $(this).parent().find(".AddFileForm").slideToggle(500, "linear");
    });
    $(".DeleteFile").click(function () {
        $("#lblDelete").text($(this).attr("dir"));
        $("#hdPath").attr("value", $(this).attr("dir"));
        $("#AddFolder").hide();
        $("#AddFile").hide();
        $("#DeleteFile").show();
        //  alert($(this).parent().find("div").html());
        // $(this).parent().find(".AddFileForm").slideToggle(500, "linear");
    });
    //Tree js
    $(function () {
        $('.tree li:has(ul)').addClass('parent_li').find(' > span').attr('title', 'Collapse this branch');
        $('.tree li.parent_li > span').on('click', function (e) {
            var children = $(this).parent('li.parent_li').find(' > ul > li');
            if (children.is(":visible")) {
                children.hide('fast');
                $(this).attr('title', 'Expand this branch').find(' > i').addClass('glyphicon-plus-sign').removeClass('glyphicon-minus-sign');
            } else {
                children.show('fast');
                $(this).attr('title', 'Collapse this branch').find(' > i').addClass('glyphicon-minus-sign').removeClass('glyphicon-plus-sign');
            }
            e.stopPropagation();
        });
    });
    //Text Editer
    //CKEDITOR.replace('ContentPlaceHolder1_txtBody');

    //Tabs
    $(function () {
        $('#myTab a:last').tab('show')
    })
    //Edit Profile
    $("#EditProfile").hide();
    $("#btnProfileEdit").click(function () {
      //  alert("sfaf");
        $("#UserProfile").hide();
        $("#EditProfile").show();
    });

    //Msg
	$(document).ready(function () {
		if($("#Msg").hasClass("show"))
			$("#Msg").removeClass("hidden");
	   $("*").click(function(){
		   	$("#Msg").removeClass("show").addClass("hidden");
		   });
			
	});
}

//for All popup Box
$(document).ready(function () {
    //Movie type popup Show
    BindEvent();
});


//Calling Bind Event For Partial Page Refres
var req = Sys.WebForms.PageRequestManager.getInstance();
req.add_endRequest(function () {
    BindEvent();
});
/// Admin palne Menu
$(document).ready(function () {
    //BindEvent();
});