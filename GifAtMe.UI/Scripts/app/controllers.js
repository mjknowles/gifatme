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
      Gif.get(function (resp) {
          $scope.users = [];
          $scope.gifs = resp.GifEntries;

          // Create of users for picker
          var flags = [], l = resp.GifEntries.length, i;
          for (i = 0; i < l; i++) {
              if (flags[resp.GifEntries[i].UserName]) continue;
              flags[resp.GifEntries[i].UserName] = true;
              $scope.users.push(resp.GifEntries[i].UserName);
          }

          // Set initial user filter
          $scope.query = {
              UserName: "not a user",
              Keyword: ""
          };

      });
  }]);
