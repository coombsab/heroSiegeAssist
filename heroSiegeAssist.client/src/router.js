import { createRouter, createWebHashHistory } from 'vue-router'
import { authGuard } from '@bcwdev/auth0provider-client'

function loadPage(page) {
  return () => import(`./pages/${page}.vue`)
}

const routes = [
  {
    path: '/',
    name: 'Home',
    component: loadPage('HomePage')
  },
  {
    path: '/about',
    name: 'About',
    component: loadPage('AboutPage')
  },
  {
    path: '/runewords',
    name: 'Runewords',
    component: loadPage('RunewordsPage')
  },
  {
    path: '/runes',
    name: 'Runes',
    component: loadPage('RunesPage')
  },
  {
    path: '/myrunes',
    name: 'MyRunes',
    component: loadPage('MyRunesPage')
  },
  {
    path: '/miscellaneous',
    name: 'Misc',
    component: loadPage('MiscPage')
  },
  {
    path: '/account',
    name: 'Account',
    component: loadPage('AccountPage'),
    beforeEnter: authGuard
  }
]

export const router = createRouter({
  linkActiveClass: 'router-link-active',
  linkExactActiveClass: 'router-link-exact-active',
  history: createWebHashHistory(),
  routes
})
