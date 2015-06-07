'use strict';

/* Services */

var gifAtMeServices = angular.module('gifAtMeServices', ['ngResource']);

gifAtMeServices.factory('gifAtMeAPI', ['$resource',
  function ($resource) {
      return {
          gifs: $resoure('/api/gifentries/:userId', {}, {
              query: { method: 'GET', params: { userId: '0000', uidsource: 'slack' }, isArray: true }
          })
      };
  }]);