console.log("From file");
//var fullname = "John Doe"; //global
//function main() {
//    var fullname = "John Doe";
//    var age = 20;

//    console.log(age);
//}

//main();


//iife immidiatley invoked function expression
(function (fullname) {
    //var fullname = "John Doe";
    var age = 20;
    console.log(fullname);
    console.log(age);
})("David Smith");

//main();

function func1()
{

}

function func2(name, family)
{
    //if (name != undefined)

}

function func3()
{
    return 10;
}

var func4 = function () {

};

console.log('-------------------------');
var res1 = func1();
console.log(res1);
console.log(typeof func3());
console.log('-------------------------');
