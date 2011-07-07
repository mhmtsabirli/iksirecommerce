function trim ( inputStringTrim ) {
	fixedTrim = '';
	lastCh = ' ';
	for (x=0; x < inputStringTrim.length; x++) {
	ch = inputStringTrim.charAt(x);
	if ((ch != ' ') || (lastCh != ' ')) {
	fixedTrim += ch;
	}
	lastCh = ch;
	}
	if (fixedTrim.charAt(fixedTrim.length - 1) == ' ') {
	fixedTrim = fixedTrim.substring(0, fixedTrim.length - 1);
	}
	return fixedTrim;
}

varCurrentRBvalue = "";

function checkRadioArray(radioButtons){
	for (var i=0; i < radioButtons.length; i++) {
	if (radioButtons[i].checked) {
	varCurrentRBvalue = radioButtons[i].value;
	return true;
	}
	}
	return false;
}


function checkCheckBox(cb){
	return cb.checked;
}

function checkSelect(select){
	return (select.selectedIndex > 0);
}

function isValidEmail(emailad){
  var exclude=/[^@\-\.\w]|^[_@\.\-]|[\._\-]{2}|[@\.]{2}|(@)[^@]*\1/;
  var check=/@[\w\-]+\./;
  var checkend=/\.[a-zA-Z]{2,3}$/;

  if(((emailad.search(exclude) != -1)||(emailad.search(check)) == -1)||(emailad.search(checkend) == -1))
    {
      return false;
    } 
    else 
    {
      return true;
    } 
}

function isValidSSN(value) {
    var re = /^([0-6]\d{2}|7[0-6]\d|77[0-2])([ \-]?)(\d{2})\2(\d{4})$/;
    if (!re.test(value)) { return false; }
    var temp = value;
    if (value.indexOf("-") != -1) { temp = (value.split("-")).join(""); }
    if (value.indexOf(" ") != -1) { temp = (value.split(" ")).join(""); }
    if (temp.substring(0, 3) == "000") { return false; }
    if (temp.substring(3, 5) == "00") { return false; }
    if (temp.substring(5, 9) == "0000") { return false; }
    return true;
}

function hideSpan(e) {
	document.getElementById(e).style.display="none";
}


function showSpan(e) {
	document.getElementById(e).style.display="block";
}

function disableAll(){
	var el = document.forms[0].elements;
	for(var i=0;i<el.length;i++){
	el[i].setAttribute('disabled',true)
	}
}

function disableAll2(){
	for (var j=0;j<document.forms[0].length;j++){
		var el = document.forms[j].elements;
		for(var i=0;i<el.length;i++){

			if (el[i].type == "select-one" || el[i].type == "radio" || el[i].type == "checkbox"){
				el[i].setAttribute('disabled',true)
			}else{
				el[i].setAttribute('readonly',true)
			}

		}
	}
}

function countLines(strtocount, cols) {
    var hard_lines = 1;
    var last = 0;
    while ( true ) {
        last = strtocount.indexOf("\n", last+1);
        hard_lines ++;
        if ( last == -1 ) break;
    }
    var soft_lines = Math.round(strtocount.length / (cols-1));
    var hard = eval("hard_lines  " + unescape("%3e") + "soft_lines;");
    if ( hard ) soft_lines = hard_lines;
    return soft_lines;
}
function cleanForm() {
    var the_form = document.forms[0];
    for ( var x in the_form ) {
        if ( ! the_form[x] ) continue;
        if( typeof the_form[x].rows != "number" ) continue;
        the_form[x].rows = countLines(the_form[x].value,the_form[x].cols) +1;
    }
    setTimeout("cleanForm();", 300);
}


function ShowAll(){
	//show all spans
	var spanCount = document.getElementsByTagName('span').length;
	for(var i=0; i<spanCount; i++){
		var span = document.getElementsByTagName('span')[i];

		if(!span.id.match('^add.*|^del.*')){
			span.style.display="block";
		}

		//hide all of the "add" and "remove" spans
		if(span.id.match('^add.*|^del.*')){
			span.style.display="none";
		}

	}

	//show all divs
	var divCount = document.getElementsByTagName('div').length;
	for(var i=0; i<divCount; i++){
		var div = document.getElementsByTagName('div')[i];
		if(!div.id.match('^add.*|^del.*')){
			div.style.display="block";
		}

	}

}


/***********************************************
* Textarea Maxlength script- © Dynamic Drive (www.dynamicdrive.com)
* This notice must stay intact for legal use.
* Visit http://www.dynamicdrive.com/ for full source code
***********************************************/
function ismaxlength(obj){
var mlength=obj.getAttribute? parseInt(obj.getAttribute("maxlength")) : ""
if (obj.getAttribute && obj.value.length>mlength)
obj.value=obj.value.substring(0,mlength)
}
/***********************************************/

function IsNumeric(strString)
   //  check for valid numeric strings	
   {
   //customize strValidChars as needed
   var strValidChars = "0123456789"; 
   var strChar;
   var blnResult = true;

   if (strString.length == 0) return false;

   //  test strString consists of valid characters listed above
   for (i = 0; i < strString.length && blnResult == true; i++)
      {
      strChar = strString.charAt(i);
      if (strValidChars.indexOf(strChar) == -1)
         {
         blnResult = false;
         }
      }
   return blnResult;
}

String.prototype.isValidDateMMDDYYYY = function() {
  var IsoDateRe = new RegExp("^([0-9]{2})/([0-9]{2})/([0-9]{4})$");

  var matches = IsoDateRe.exec(this);
  if (!matches) return false;

  var composedDate = new Date(matches[3], (matches[1] - 1), matches[2]);

  return ((composedDate.getMonth() == (matches[1] - 1)) &&
          (composedDate.getDate() == matches[2]) &&
          (composedDate.getFullYear() == matches[3]));
}

String.prototype.isValidDateMMYYYY = function() {
  var IsoDateRe = new RegExp("^([0-9]{2})/([0-9]{2})/([0-9]{4})$");

  var matches = IsoDateRe.exec("01/"+this);
  if (!matches) return false;

  var composedDate = new Date(matches[3], (matches[2] - 1), matches[1]);

  return ((composedDate.getMonth() == (matches[2] - 1)) &&
          (composedDate.getDate() == matches[1]) &&
          (composedDate.getFullYear() == matches[3]));
}

String.prototype.isValidDate = function() {
  var IsoDateRe = new RegExp("^([0-9]{4})-([0-9]{2})-([0-9]{2})$");

  var matches = IsoDateRe.exec(this);
  if (!matches) return false;

  var composedDate = new Date(matches[1], (matches[2] - 1), matches[3]);

  return ((composedDate.getMonth() == (matches[2] - 1)) &&
          (composedDate.getDate() == matches[3]) &&
          (composedDate.getFullYear() == matches[1]));

	//var a = "2007-02-28";
	//alert(a + (a.isValidDate() ? " is a valid date" : " is not a valid date"));
}

