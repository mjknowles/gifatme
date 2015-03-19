'use strict';

/* Controllers */

var gifAtMeControllers = angular.module('gifAtMeControllers', []);

/*phonecatControllers.controller('PhoneListCtrl', ['$scope', 'Phone',
  function ($scope, Phone) {
      $scope.phones = Phone.query();
      $scope.orderProp = 'age';
  }]);
  */
gifAtMeControllers.controller('UserListCtrl', ['$scope', 'User',
  function ($scope, User) {
      $scope.users = User.query();
      $scope.orderProp = 'userName';
  }]);

/*phonecatControllers.controller('PhoneDetailCtrl', ['$scope', '$routeParams', 'Phone',
  function ($scope, $routeParams, Phone) {
      $scope.phone = Phone.get({ phoneId: $routeParams.phoneId }, function (phone) {
          $scope.mainImageUrl = phone.images[0];
      });

      $scope.setImage = function (imageUrl) {
          $scope.mainImageUrl = imageUrl;
      }
  }]);
 */
gifAtMeControllers.controller('UserGifsCtrl', ['$scope', '$routeParams', 'User',
  function ($scope, $routeParams, Gif) {
      $scope.phone = Gif.get({ userName: $routeParams.userName }, function (gifs) {
          $scope.gifs = gifs;
      });
  }]);
