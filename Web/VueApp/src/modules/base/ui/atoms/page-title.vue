<template>
  <h6 class="q-my-none text-weight-bold">{{ pageTitle }}</h6>
  <span class="text-caption">{{ breadCrumbHead }} &raquo; {{ pageTitle }}</span>
  <q-separator class="q-my-lg"></q-separator>
</template>

<script setup lang="ts">
import { computed } from 'vue'
import { useRoute } from 'vue-router'

const routeData = useRoute()
const parentRoute = computed(() =>
  routeData.matched.length > 1
    ? routeData.matched[routeData.matched.length - 2]
    : null,
)

const breadCrumbHead = computed(
  () => parentRoute.value?.meta.breadCrumbHead ?? 'Home',
)

const pageTitle = computed(() => routeData.name)
</script>

<style scoped></style>
