$(document).ready(() => {
	var converter = new showdown.Converter();
	$.get({url: "https://raw.githubusercontent.com/samueldonovan1701/SharpTrends/main/README.md", dataType:"text"})
		.done((data) =>
		{
			var html = converter.makeHtml(data);
			$("#readme").html(html);
		})
		.fail((data) => {
			$("#readme").html("<h1>Cross-Origin Request Failed: "+
	      		"You must have a CORS extension installed"+
	      		" for this tool to function</h1>");
		});
});