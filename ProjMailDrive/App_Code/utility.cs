using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for utility
/// </summary>
public class utility
{
	public static String SuccessMsg(String msg)
    {
        return "<span class=\"msg alert alert-success\"><span  class=\"alert alert-success glyphicon glyphicon-ok-circle\"></span> " + msg + "</span>";
    }
    public static String ErrorMsg(String msg)
    {
        return "<span class=\" msg alert alert-danger\"><span class=\"alert alert-danger glyphicon glyphicon-remove-circle\"></span> " + msg + "</span>";
    }
}