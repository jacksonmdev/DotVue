<template>
  <q-btn v-bind="{ ...attrs }" unelevated class="app--button"></q-btn>
</template>

<script setup lang="ts">
import { useAttrs } from 'vue'

const attrs = useAttrs()
</script>

<style scoped>
.app--button {
  min-width: 150px;
  padding: 10px !important;
}
</style>
