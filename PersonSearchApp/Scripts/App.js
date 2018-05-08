var app = angular.module("App", []);
app.controller("SearchController", function ($scope) {

    $scople.person = []

    $scope.searchPeople() = function () {

        $http.get('api/Search/GetPeople', {
            cache: false,
            params: {},
        }).then(function (response) {

            angular.forEach(response.data, function (value) {
                $scope.person({
                    fname: value.fname,
                    lname: value.lname,
                    age: value.age,
                    addr: value.addr,
                    interests: value.interests,
                    picture: value.picture
                });

            });

        });
    }

    $scope.addPerson() = function () {
        var newPerson = {};

        newPerson = {
            fname: $scope.fname,
            lname: $scope.lname,
            age: $scope.age,
            addr: $scope.addr,
            interests: $scope.interests,
            picture: $scope.picture
        };

        $http.post('api/Search/PostAddPerson', newPerson).then(function (res) {
            debugger;
        });
    };
});