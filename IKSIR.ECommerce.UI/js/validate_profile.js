/*
validate_profile.js
*/

function SubmitForm(f){

//-------------------------------------------------------
if ( !checkSelect(f.a000100_job_dd) ) {
alert ('All fields are required. Please enter a value.');
f.a000100_job_dd.focus();
return;
}
//-------------------------------------------------------
jsValue = trim(f.a000110_fname.value);
if (jsValue == ''||jsValue == null){
alert ('All fields are required. Please enter a value.');
f.a000110_fname.focus();
return;
}
//-------------------------------------------------------
jsValue = trim(f.a000120_lname.value);
if (jsValue == ''||jsValue == null){
alert ('All fields are required. Please enter a value.');
f.a000120_lname.focus();
return;
}
//-------------------------------------------------------
if ( !checkRadioArray(f.a000130_race_rb) ) {
alert ('All fields are required. Please enter a value.');
f.a000130_race_rb[0].focus();
return;
}
//-------------------------------------------------------
if ( !checkRadioArray(f.a000140_gender_rb) ) {
alert ('All fields are required. Please enter a value.');
f.a000140_gender_rb[0].focus();
return;
}
	if (varCurrentRBvalue == "Female") {
		//-------------------------------------------------------
		jsValue = trim(f.a000370_maiden_name.value);
		if (jsValue == ''||jsValue == null){
		alert ('All fields are required. Please enter a value.');
		f.a000370_maiden_name.focus();
		return;
		}
	}

//-------------------------------------------------------
jsValue = trim(f.a000150_address.value);
if (jsValue == ''||jsValue == null){
alert ('All fields are required. Please enter a value.');
f.a000150_address.focus();
return;
}
//-------------------------------------------------------
jsValue = trim(f.a000160_city.value);
if (jsValue == ''||jsValue == null){
alert ('All fields are required. Please enter a value.');
f.a000160_city.focus();
return;
}
//-------------------------------------------------------
jsValue = trim(f.a000170_state.value);
if (jsValue == ''||jsValue == null){
alert ('All fields are required. Please enter a value.');
f.a000170_state.focus();
return;
}
//-------------------------------------------------------
jsValue = trim(f.a000180_zip.value);
if (jsValue == ''||jsValue == null){
alert ('All fields are required. Please enter a value.');
f.a000180_zip.focus();
return;
}
//-------------------------------------------------------
jsValue = trim(f.a000190_country.value);
if (jsValue == ''||jsValue == null){
alert ('All fields are required. Please enter a value.');
f.a000190_country.focus();
return;
}
//-------------------------------------------------------
jsValue = trim(f.a000200_homephone_area.value);
if (jsValue == ''||jsValue == null){
alert ('All fields are required. Please enter a value.');
f.a000200_homephone_area.focus();
return;
}
//-------------------------------------------------------
jsValue = trim(f.a000210_homephone_3.value);
if (jsValue == ''||jsValue == null){
alert ('All fields are required. Please enter a value.');
f.a000210_homephone_3.focus();
return;
}
//-------------------------------------------------------
jsValue = trim(f.a000220_homephone_4.value);
if (jsValue == ''||jsValue == null){
alert ('All fields are required. Please enter a value.');
f.a000220_homephone_4.focus();
return;
}

/*
	//-------------------------------------------------------
	jsValue = trim(f.a000230_businessphone_area.value);
	if (jsValue == ''||jsValue == null){
	alert ('All fields are required. Please enter a value.');
	f.a000230_businessphone_area.focus();
	return;
	}
	//-------------------------------------------------------
	jsValue = trim(f.a000240_businessphone_3.value);
	if (jsValue == ''||jsValue == null){
	alert ('All fields are required. Please enter a value.');
	f.a000240_businessphone_3.focus();
	return;
	}
	//-------------------------------------------------------
	jsValue = trim(f.a000250_businessphone_4.value);
	if (jsValue == ''||jsValue == null){
	alert ('All fields are required. Please enter a value.');
	f.a000250_businessphone_4.focus();
	return;
	}
	//-------------------------------------------------------
	jsValue = trim(f.a000260_cellphone_area.value);
	if (jsValue == ''||jsValue == null){
	alert ('All fields are required. Please enter a value.');
	f.a000260_cellphone_area.focus();
	return;
	}
	//-------------------------------------------------------
	jsValue = trim(f.a000270_cellphone_3.value);
	if (jsValue == ''||jsValue == null){
	alert ('All fields are required. Please enter a value.');
	f.a000270_cellphone_3.focus();
	return;
	}
	//-------------------------------------------------------
	jsValue = trim(f.a000280_cellphone_4.value);
	if (jsValue == ''||jsValue == null){
	alert ('All fields are required. Please enter a value.');
	f.a000280_cellphone_4.focus();
	return;
	}
*/

//-------------------------------------------------------
jsValue = trim(f.a000290_email.value);
if (!isValidEmail(jsValue)){
	alert ("Please enter a valid e-mail addesss.");
	f.a000290_email.focus();
	return;
}
//-------------------------------------------------------
jsValue = trim(f.a000300_pob.value);
if (jsValue == ''||jsValue == null){
alert ('All fields are required. Please enter a value.');
f.a000300_pob.focus();
return;
}

//-------------------------------------------------------
jsValue = trim(f.a000305_dob.value);
if (!jsValue.isValidDateMMDDYYYY()){
alert ('Please enter a valid date formatted as MM/DD/YYYY');
f.a000305_dob.focus();
return;
}

//-------------------------------------------------------
jsValue = trim(f.a000310_ssn.value);
if (!isValidSSN(jsValue)){
alert ('You must enter a valid SSN. Numbers and dashes only.');
f.a000310_ssn.focus();
return;
}

//-------------------------------------------------------
jsValue = trim(f.a000320_aka.value);
if (jsValue == ''||jsValue == null){
alert ('All fields are required. Please enter a value.');
f.a000320_aka.focus();
return;
}
//-------------------------------------------------------
jsValue = trim(f.a000330_no_naturalization.value);
if (jsValue == ''||jsValue == null){
alert ('All fields are required. Please enter a value.');
f.a000330_no_naturalization.focus();
return;
}


if (trim(f.a000330_no_naturalization.value).toLowerCase() != "none") {
	//-------------------------------------------------------
	jsValue = trim(f.a000340_poe.value);
	if (jsValue == ''||jsValue == null){
	alert ('All fields are required. Please enter a value.');
	f.a000340_poe.focus();
	return;
	}
}

//-------------------------------------------------------
if ( !checkRadioArray(f.a000350_marital_rb) ) {
alert ('All fields are required. Please enter a value.');
f.a000350_marital_rb[0].focus();
return;
}

	if (varCurrentRBvalue == "Married") {
		//-------------------------------------------------------
		jsValue = trim(f.a000360_fullname_spouse.value);
		if (jsValue == ''||jsValue == null){
		alert ('All fields are required. Please enter a value.');
		f.a000360_fullname_spouse.focus();
		return;
		}
	}

f.action = 'profile_process.asp';
f.submit();
}
