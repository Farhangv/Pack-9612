(function () {

    var obj = new Object();
    obj.name = "John";
    obj.family = "Doe";
    obj.writeFullName = function () {
        console.log(this.name + " " + this.family);
    };

    console.log(obj.name);
    console.log(obj.family);
    obj.writeFullName();
});//();

(function () {

    var obj = {
        name: "David",
        family: "Smith",
        age: 20,
        writeStudentDetails: function () {
            console.log(this.name + ' ' + this.family + ' ' + this.age);
        },
        courses: ['C#', 'JavaScript', 'ASP.NET MVC'],
        writeStudentCourses: function () {
            for (var i = 0; i < this.courses.length; i++) {
                console.log(this.courses[i]);
            }
        }
    };

    obj.writeStudentDetails();
    obj.writeStudentCourses();

});//();

(function () {
    function Student() {
        this.name = "";
        this.family = "";
        this.courses = [];

        this.writeStudentDetails = function () {
            console.log(this.name + ' ' + this.family);
            for (var i = 0; i < this.courses.length; i++) {
                console.log(this.courses[i]);
            }
        };
    };

    var std = new Student();
    std.name = "Sarah";
    std.family = "Smith";
    std.courses = ['Java', 'PHP', 'Oracle'];
    std.writeStudentDetails();


})();