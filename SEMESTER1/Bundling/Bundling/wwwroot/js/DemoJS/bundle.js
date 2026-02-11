const initialize = () => {
    let sliders = document.getElementsByClassName("slider");
    let i = 0;
    for (i = 0; i < sliders.length; i++) {
        // we moeten zowel op het input als het change event reageren,
        // zie http://stackoverflow.com/questions/18544890
        sliders[i].addEventListener("change", update);
        sliders[i].addEventListener("input", update);
    }
 
};

const update = () => {
  
};

window.addEventListener("load", initialize, false);
// JavaScript Document

var x= 0;  
var y=-1;  
var z= 4;  
if (x>y && x>z)  
{  
        if (y>z)  
        {  
            console.log(x + ", " + y + ", " +z);  
        }  
        else  
        {  
            console.log(x + ", " + z + ", " +y);  
        }  
}  
else if (y>x && y >z)  
{  
        if (x>z)  
        {  
             console.log(y + ", " + x + ", " +z);  
        }  
        else  
        {  
             console.log(y + ", " + z + ", " +x);  
        }  
}  
else if (z>x && z>y)  
{  
        if (x>y)  
        {  
            console.log(z + ", " + x + ", " +y);  
        }  
        else  
        {  
            console.log(z + ", " + y + ", " +x);  
        }  
}          

const setup = () => {
    let sum = 0;

    let waarde = 100;
    for (let x = 5; x < waarde; x++) {
        if (x % 3 === 0 && x % 5 === 0) {
            sum += x;
        }
    }
    console.log(sum);
   
};

window.addEventListener("load", setup);