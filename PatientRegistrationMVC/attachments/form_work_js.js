// JavaScript Document

function numbersonly(input){
	
	var regex = /[^0-9]/gi;	
	input.value = input.value.replace(regex,"");
	
	
}

function lettersonly(input){
	
	var regex = /s[^a-z]/gi;	
	input.value = input.value.replace(regex,"");
	
	
}