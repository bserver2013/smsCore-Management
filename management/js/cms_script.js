$(document).ready(function() {
	$("#noti_err").hide();
	$("#noti_ok").hide();
});	
function deletemenow(str)
{
	var xmlvar;
	if(window.XMLHttpRequest) { xmlvar = new XMLHttpRequest(); } else { xmlvar = new ActiveXObject("Microsoft.XMLHTTP"); }
	xmlvar.onreadystatechange=function() { if(xmlvar.readyState==4 && xmlvar.status==200)
	{	
		var err = xmlvar.responseText;
		if(err.match("Failed"))
		{	
			$("#noti_err").show();
			$("#noti_err").fadeIn();
		} else {
			$("#notime").append(" " + err);
			$("#noti_ok").show();
			$("#noti_ok").fadeIn();
		}
		setDelay();
	} } 
	xmlvar.open("GET","controller/PHPScriptController.php?deleteme=true"+"&id="+str,true); 
	xmlvar.send(null);
}
var ctrx = 0;
function setDelay()
{
	ctrx +=1;
	if(ctrx == 2)
	{
		window.location = "?m=sent%20items";
	}
	setTimeout("setDelay()", 1000);
}
function setDelayHide()
{
	ctrx +=1;
	if(ctrx == 2)
	{
		window.location = "?m=add%20user";
	}
	setTimeout("setDelayHide()", 1000);
}
function block_sel(str) { localStorage.clickcount = str; }
function clear_cache() { localStorage.clickcount = 0; localStorage.cho = ""; }
function sub_cho(str) { localStorage.cho = str; }
function logMeOut()
{
	var xmlvar;
	if(window.XMLHttpRequest) { xmlvar = new XMLHttpRequest(); } else { xmlvar = new ActiveXObject("Microsoft.XMLHTTP"); }
	xmlvar.onreadystatechange=function() { if(xmlvar.readyState==4 && xmlvar.status==200)
	{	
		window.location = "../";
		clear_cache();
	} } 
	xmlvar.open("GET","controller/PHPScriptController.php?destroy_everything=true",true); 
	xmlvar.send(null);
}

