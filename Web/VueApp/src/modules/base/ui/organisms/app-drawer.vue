<template>
  <q-drawer
    show-if-above
    v-model="modelValue"
    :width="250"
    :side="side"
    bordered
  >
    <SidebarMenu
      :title="$t('common.app.sidebar_default_menu')"
      :menu="defaultMenu"
    ></SidebarMenu>
    <q-separator></q-separator>
  </q-drawer>
</template>

<script setup lang="ts">
import { computed, useAttrs } from 'vue'
import { SidebarNavigation } from 'src/store'

const attrs = useAttrs()
const modelValue = defineModel<boolean>()

const side = computed(() =>
  Object.prototype.hasOwnProperty.call(attrs, 'right') ? 'right' : 'left',
)

const defaultMenu = computed(() => SidebarNavigation().defaultMenu)
</script>

<style scoped></style>
