var input = document.getElementById('regions');
// var route=document.getElementById('routetype');
var city=document.getElementById('city');
var dropList = document.querySelector('ul.drop');
var cities = document.getElementById('cities'); 
// var routetypes=document.getElementById('rtype');

input.addEventListener('focus', show, false);
input.addEventListener('blur', hide, false);

//нужно другие методы по типу тех что для input
// route.addEventListener('focus', showrt, false);
// route.addEventListener('blur', hidert, false);

dropList.addEventListener('click', dropSelect, false);
cities.addEventListener('click', dropselect, false);
// routetypes.addEventListener('click', dropSelectrt, false);

function hide(){
  setTimeout(() =>
    dropList.classList.remove('visible'), 300);
}
function show(){
  setTimeout(() =>
    dropList.classList.add('visible'), 300);
}

// function hidert(){
//   setTimeout(() =>
//     routetypes.classList.remove('visible'), 300);
// }
// function showrt(){
//   setTimeout(() =>
//    routetypes.classList.add('visible'), 300);
//   // setTimeout(() =>
//   //   cities.classList.remove('visible'), 300);  
// }

function dropSelect(e) {
  input.value = e.target.textContent
  hide();
  // getcities(input.value);
  setTimeout(() =>
    cities.classList.add('visible'), 300);
}
function dropselect(e)
{
	city.value = e.target.textContent
	setTimeout(() =>
  		cities.classList.remove('visible'),300);
}
// function dropSelectrt(e)
// {
// 	route.value = e.target.textContent
// 	setTimeout(() =>
//   		routetypes.classList.remove('visible'),300);
// }

// function getcities(t)
// {

// }


function filter() {
  var input, filter, ul, a, i, li;
 	input = document.querySelector('input.drop');
	var dropList = document.querySelector('ul.drop');
  	filter = input.value.toUpperCase();
  	// ul = document.getElementById("myDropdown");
  	a = dropList.getElementsByTagName("li");
  for (i = 0; i < a.length; i++) {
    if (a[i].innerHTML.toUpperCase().indexOf(filter) > -1) {
      a[i].style.display = "";
    } else {
      a[i].style.display = "none";
    }
  }
}