<%@ Register TagPrefix="cc1" Namespace="IDAutomation.DataMatrixServerControl" Assembly="IDAutomation.DataMatrixServerControl" %>
<%@ Page language="c#" Codebehind="IDAutomationStreamingDataMatrix.aspx.cs" AutoEventWireup="false" Inherits="DataMatrixStreamCS.IDAutomationStreamingDataMatrix" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>IDAutomationStreamingDataMatrix</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="IDAutomationStreamingDataMatrix" method="post" runat="server">
			<cc1:DataMatrixBarcode id="DataMatrixBarcode1" style="Z-INDEX: 101; LEFT: 312px; POSITION: absolute; TOP: 344px"
				runat="server" StreamImage="True"></cc1:DataMatrixBarcode>
		</form>
	</body>
</HTML>
