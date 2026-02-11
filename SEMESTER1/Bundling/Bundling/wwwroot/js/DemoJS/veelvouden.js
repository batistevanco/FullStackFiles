
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