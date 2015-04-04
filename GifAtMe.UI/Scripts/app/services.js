'use strict';

/* Services */

var gifAtMeServices = angular.module('gifAtMeServices', ['ngResource']);

/*
phonecatServices.factory('Phone', ['$resource',
  function ($resource) {
      return $resource('phones/:phoneId.json', {}, {
          query: { method: 'GET', params: { phoneId: 'phones' }, isArray: true }
      });
  }]);
*/

gifAtMeServices.factory('Gif', ['$resource',
  function ($resource) {
      return $resource('/api/gifentries', {}, {
          query: { method: 'GET' }
      });
  }]);