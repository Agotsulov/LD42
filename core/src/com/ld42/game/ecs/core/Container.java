package com.ld42.game.ecs.core;

public interface Container<T> {

    boolean add(T o);

    boolean contains(T o);

    boolean remove(T o);

    int size();

    T get(int i);

}
