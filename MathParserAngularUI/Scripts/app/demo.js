
appRoot.controller('DemoController', function ($scope, $location, $resource) {

    var userResource = $resource('/api/users', {}, { update: { method: 'PUT' } });
    $scope.usersList = [];
    
    userResource.query(function (data) {
        $scope.usersList = [];
        angular.forEach(data, function (userData) {
            $scope.usersList.push(userData);
        });
    });

    $scope.selectedUsers = [];

    $scope.$watchCollection('selectedUsers', function () {
        $scope.selectedUser = angular.copy($scope.selectedUsers[0]);
    });


    var init = function () {

    }

    init();
});