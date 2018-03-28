import {
  handleActions
} from 'redux-actions'
import {
  UPDATE,
  REGISTER,
  CHATID,
  FAMILY,
  JOB
} from '../types/userState'

export default handleActions({
  [UPDATE](state, action = {}) {
    return { ...state,
      user: action.model
    }
  },
  [REGISTER](state, action = {}) {
    return {
      ...state,
      hasRegister: action.model
    }
  },
  [CHATID](state, action = {}) {
    return {
      ...state,
      chatId: action.model
    }
  },
  [FAMILY](state, action = {}) {
    return {
      ...state,
      family: action.model
    }
  },
  [JOB](state, action = {}) {
    return {
      ...state,
      job: action.model
    }
  }
}, {
  user: null,
  hasRegister: false,
  chatId: null,
  family: null,
  job: null
})
