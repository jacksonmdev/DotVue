import { type RouteRecordRaw } from 'vue-router'

export const routes: RouteRecordRaw[] = [
  {
    path: '/:pathMatch(.*)*',
    component: () => import('src/pages/404-page.vue'),
  },
  {
    path: '/',
    meta: {
      breadCrumbHead: 'Vue Base Enterprise',
    },
    component: () => import('src/layouts/main-layout.vue'),
    children: [
      {
        path: '',
        name: 'Home',
        component: () => import('src/pages/index-page.vue'),
      },
    ],
  },
]
