<template>
    <vue-advanced-chat
      :current-user-id="currentUserId"
      :rooms="JSON.stringify(rooms)"
      :messages="JSON.stringify(messages)"
      :room-actions="JSON.stringify(roomActions)"
    />
  </template>
  
  <script>
    import { register } from 'vue-advanced-chat'
    register()
  
    // Or if you used CDN import
    // window['vue-advanced-chat'].register()
  
    export default {
      data() {
        return {
          currentUserId: '1234',
          rooms: [],
          messages: [],
          roomActions: [
            { name: 'inviteUser', title: 'Invite User' },
            { name: 'removeUser', title: 'Remove User' },
            { name: 'deleteRoom', title: 'Delete Room' }
          ]
        }
      }
    }
  </script>