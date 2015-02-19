angular.module( 'main')
    .controller('MainController', ['$scope', '$http', function ($scope, $http) {
        $scope.$watch('mathString', function (newVal, oldVal) {
            $scope.mathResult = "";
            if (newVal !== oldVal) {
                $http.get('/api/math?value=' + newVal).success(function (result) {
                    $scope.mathResult = result;
                });
            }
        });
    }]);