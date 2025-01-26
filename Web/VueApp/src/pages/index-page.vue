<template>
  <div class="row">
    <div class="col-12 col-sm-12 col-md-6 col-lg-4">Hello world</div>
  </div>
</template>

<script setup lang="ts">
import { usePageHead, t } from 'modules/base/composables'

usePageHead({
  title: t('common.app.name'),
})
</script>

<style scoped></style>
