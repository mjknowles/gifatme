'use strict';

/* Controllers */

var gifAtMeControllers = angular.module('gifAtMeControllers', []);

/*phonecatControllers.controller('PhoneListCtrl', ['$scope', 'Phone',
  function ($scope, Phone) {
      $scope.phones = Phone.query();
      $scope.orderProp = 'age';
  }]);
  */

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
gifAtMeControllers.controller('GifsCtrl', ['$scope', 'Gif',
  function ($scope, Gif) {
      Gif.get(function(resp) {
          $scope.gifs = resp.GifEntries;
      });
  }]);
