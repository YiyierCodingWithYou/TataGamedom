/**
 * main.js
 *
 * Bootstraps Vuetify and other plugins then mounts the App`
 */

// Components
import App from './App.vue'

// Composables
import { createApp } from 'vue'

// Plugins
import { registerPlugins } from '@/plugins'

// Vuex
import store from './store'

//GoogleLogin
import vue3GoogleLogin from 'vue3-google-login'


const app = createApp(App)

registerPlugins(app)

app.use(vue3GoogleLogin, {
    clientId: '627216365322-r1p2k6inqcll60f8e5ijpejrlp7galoe.apps.googleusercontent.com'
})


app.use(store).mount('#app')
