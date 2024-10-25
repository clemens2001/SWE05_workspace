package at.fhooe.me.android.test.view


import android.app.Activity
import android.os.Bundle
import android.util.Log
import android.view.View
import android.view.ViewGroup
import at.fhooe.me.android.test.view.databinding.ActivityMainDeepBinding
import at.fhooe.me.android.test.view.databinding.ActivityMainScrollBinding
import at.fhooe.me.android.test.view.databinding.ActivityMainShallowBinding

const val TAG: String = "ViewTest"

class MainActivity : Activity(), View.OnClickListener {

//    lateinit var binding: ActivityMainShallowBinding
//    lateinit var binding: ActivityMainDeepBinding
    lateinit var binding: ActivityMainScrollBinding

    class MyOnClickListener : View.OnClickListener {
        override fun onClick(_v: View?) {
            when (_v?.id) {
                R.id.button_03 -> {
                    Log.d(TAG, "MyOnClickListener::onClick Button 03 clicked")
                }
                R.id.button_04 -> {
                    Log.d(TAG, "MyOnClickListener::onClick Button 04 clicked")
                }
                else -> {
                    Log.d(TAG, "MyOnClickListener::onClick unhandled onClick id encountered")
                }
            }
        }

    }

    override fun addContentView(view: View?, params: ViewGroup.LayoutParams?) {
        super.addContentView(view, params)
    }

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
//        binding = ActivityMainShallowBinding.inflate(layoutInflater)
//        binding = ActivityMainDeepBinding.inflate(layoutInflater)
        binding = ActivityMainScrollBinding.inflate(layoutInflater)
        setContentView(binding.root)


        val listener: View.OnClickListener = MyOnClickListener()

        binding.button01.setOnClickListener(this)
        binding.button02.setOnClickListener(this)
        binding.button03.setOnClickListener(listener)
        binding.button04.setOnClickListener(listener)
        binding.button05.setOnClickListener({ foo ->
            Log.d(TAG, "MainActivity anonomous onClickListener of Button 05")
        })
        binding.button06.setOnClickListener({ _v ->
            Log.d(TAG, "MainActivity anonomous onClickListener of Button 06")
        })
        val f: Float = 1f
        val s: String = f.toString()
    }

    fun ownClickListener(_v: View?) {
        when (_v?.id) {
            else -> {
                Log.d(TAG, "MainActivity::ownClickListener unhandled onClick id encountered")
            }
        }
    }

    override fun onClick(_v: View?) {
        when(_v?.id) {
            R.id.button_01 -> {
                Log.d(TAG, "MainActivity::onClick Button 01 clicked")
            }
            R.id.button_02 -> {
                Log.d(TAG, "MainActivity::onClick Button 02 clicked")
            }
            else -> {
                Log.d(TAG, "MainActivity::onClick unhandled onClick id encountered")
            }
        }
    }
}